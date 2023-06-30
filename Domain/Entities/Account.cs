using Application.Domain.Enums;
using Ardalis.GuardClauses;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Entities;

public record AccountId
{
    public Guid Value { get; init; }
    public AccountId(Guid value) => Value = value;
    protected AccountId() { }
}

public class Account : AggregateRoot
{
    private HashSet<AccountEntry> _accountEntries;

    //TODO: Set caching mechanism for calculating balances based on transactions
    public string Name { get; protected set; }
    public AccountType Type { get; protected set; }
    public string Number { get; protected set; }
    public CurrencyCode Currency { get; protected set; }
    public DateTime? OpenedDate { get; protected set; }
    public decimal? OpeningBalance { get; private set; }
    public bool IsCash { get; protected set; }
    public bool IsElegibleForPayment { get; protected set; }
    public IReadOnlyCollection<AccountEntry> AccountEntries => _accountEntries;

    public Account(string name, AccountType type, string number, CurrencyCode currency, bool isCash = false, bool isElegibleForPayment = false)
    {
        //TODO: Change for Guard Clauses
        if (isCash && type != AccountType.Asset) throw new Exception("Error creating account. Account cannot be marked as cash if is not of type asset.");
        if (IsElegibleForPayment && (type == AccountType.Expense || type == AccountType.Income)) throw new Exception("Income and Expenses accounts cannot be mark as payment eligible.");

        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        Number = number;
        Currency = currency;
        IsCash = isCash;
        IsElegibleForPayment = isElegibleForPayment;
        _accountEntries = new HashSet<AccountEntry>();
    }

    internal void RegisterAccountMovement(Guid transactionId, Money amount)
    {
        IsAccountOpen();
        Guard.Against.Null(amount, nameof(amount));
        Guard.Against.Zero(amount.Value, nameof(amount));

        if (amount.Currency != Currency) throw new InvalidOperationException("The entry currency cannot be different from the account currency");

        _accountEntries.Add(new AccountEntry(Id, transactionId, amount));
    }

    public Money GetBalance()
    {
        IsAccountOpen();
        var openingBalance = new Money(OpeningBalance!.Value, Currency);

        if (_accountEntries is null || _accountEntries.Count < 1)
            return openingBalance;

        var balance = _accountEntries
            .Select(x => x.Amount)
            .Aggregate((prev, actual) => prev + actual);

        balance += openingBalance;

        return balance;
    }

    public void OpenAccount(decimal openingBalance, DateTime now)
    {
        if (openingBalance < 0 && Type != AccountType.Liability) throw new Exception("Error creating account. Only Liability type accounts can have negative opening balance.");
        OpeningBalance = openingBalance;
        OpenedDate = now;
    }

    //TODO: Refactor this to return a boolean and not to throw an exception.
    private void IsAccountOpen()
    {
        if (!OpeningBalance.HasValue) throw new Exception("This account is not active because an opening balance hasn't been set.");
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Account() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
