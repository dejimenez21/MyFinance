using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Expenses.Domain.Accounts;

public class PaymentAccount : AggregateRoot
{
    public string Name { get; private set; }
    public PaymentMethod Method { get; private set; }
    public string Number { get; private set; }
    public CurrencyCode[] Currencies { get; private set; }
    public BankCode? Bank { get; private set; }
    public PaymentNetwork? Network { get; private set; }

    public PaymentAccount(Guid id, string name, PaymentMethod method, string number, CurrencyCode[] currencies, BankCode? bank, PaymentNetwork? network)
    {
        Id = id;
        Name = name;
        Method = method;
        Number = number;
        Currencies = currencies;
        Bank = bank;
        Network = network;
    }

    private PaymentAccount() { }
}

public enum PaymentMethod
{
    CASH,
    CREDIT_CARD,
    BANK_ACCOUNT
}
