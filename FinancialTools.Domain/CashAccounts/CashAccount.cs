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

    private CashAccount()
    {
        
    }

    public CashAccount(string name, bool isElegibleForPayment, string lastLocation, CurrencyCode currency, decimal balance)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsElegibleForPayment = isElegibleForPayment;
        LastLocation = lastLocation;
        Currency = currency;
        Balance = balance;
    }
}
