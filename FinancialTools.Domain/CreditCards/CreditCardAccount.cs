using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.CreditCards;

public class CreditCardAccount : Entity
{
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
}
 