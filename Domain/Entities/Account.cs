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
    public DateTime OpenedDate { get; protected set; }
    public decimal OpeningBalance { get; private set; }
    public bool IsCash { get; protected set; }
    public bool IsElegibleForPayment { get; protected set; }
    public IReadOnlyCollection<AccountEntry> AccountEntries => _accountEntries;

    protected Account() { }

    public Account(string name, AccountType type, string number, CurrencyCode currency, DateTime openedDate, decimal openingBalance, DateTime now, bool isCash = false, bool isElegibleForPayment = false)
    {
        if (OpenedDate > now) throw new Exception("Error creating account. OpenedDate can't be in the future.");
        if (OpeningBalance < 0) throw new Exception("Error creating account. OpeningBalance can't be negative.");
        if (isCash && type != AccountType.Asset) throw new Exception("Error creating account. Account cannot be marked as cash if is not of type asset.");
        if (IsElegibleForPayment && (type == AccountType.Expense || type == AccountType.Income)) throw new Exception("Income and Expenses accounts cannot be mark as payment eligible.");

        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        Number = number;
        Currency = currency;
        OpenedDate = openedDate;
        OpeningBalance = openingBalance;
        IsCash = isCash;
        IsElegibleForPayment = isElegibleForPayment;
        _accountEntries = new HashSet<AccountEntry>();
    }

    internal void RegisterAccountMovement(Guid transactionId, Money amount)
    {
        Guard.Against.Null(amount, nameof(amount));
        Guard.Against.Zero(amount.Value, nameof(amount));

        if (amount.Currency != Currency) throw new InvalidOperationException("The entry currency cannot be different from the account currency");

        _accountEntries.Add(new AccountEntry(Id, transactionId, amount));
    }

    public Money GetBalance()
    {
        var openingBalance = new Money(OpeningBalance, Currency);

        if (_accountEntries is null || _accountEntries.Count < 1)
            return openingBalance;

        var balance = _accountEntries
            .Select(x => x.Amount)
            .Aggregate((prev, actual) => prev + actual);

        balance += openingBalance;

        return balance;
    }

}
