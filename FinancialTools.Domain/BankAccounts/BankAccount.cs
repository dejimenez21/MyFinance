using FinancialTools.Domain.Common;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.BankAccounts;

public class BankAccount : AggregateRoot
{
    public string Name { get; private set; }
    public string Number { get; private set; }
    public BankCode Bank { get; private set; }
    public CurrencyCode Currency { get; private set; }
    public BankAccountType Type { get; private set; }
    public CardDetails? DebitCard { get; private set; }

    public BankAccount(Guid id, string name, string number, BankCode bank, CurrencyCode currency, BankAccountType type)
    {
        Id = id;
        Name = name;
        Number = number;
        Bank = bank;
        Currency = currency;
        Type = type;
        DebitCard = null;
    }

    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BankAccount() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}
