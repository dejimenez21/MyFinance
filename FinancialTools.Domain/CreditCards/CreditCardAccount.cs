using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.CreditCards;

public class CreditCardAccount : Entity
{
    public Guid CreditCardId { get; set; }
    public CurrencyCode Currency { get; private set; }
    public decimal CreditLimit { get; set; }
    public decimal CurrentBalance { get; private set; }
    public decimal LastStatementBalance { get; private set; }

    public CreditCardAccount(CurrencyCode currency, decimal currentBalance)
    {
        Id = Guid.NewGuid();
        Currency = currency;
        CurrentBalance = currentBalance;
        LastStatementBalance = 0;
    }


    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CreditCardAccount() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}
