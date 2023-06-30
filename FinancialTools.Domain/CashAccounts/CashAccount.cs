using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.CashAccounts;

public class CashAccount : AggregateRoot
{
    public string Name { get; private set; }
    public bool IsElegibleForPayment { get; private set; }
    public string LastLocation { get; private set; }
    public CurrencyCode Currency { get; private set; }
    public decimal Balance { get; private set; }

    public CashAccount(string name, bool isElegibleForPayment, string lastLocation, CurrencyCode currency, decimal balance)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsElegibleForPayment = isElegibleForPayment;
        LastLocation = lastLocation;
        Currency = currency;
        Balance = balance;
    }

    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CashAccount() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}
