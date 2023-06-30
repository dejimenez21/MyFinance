using Application.Domain.Enums;
using SharedKernel.Domain.Enums;

namespace Domain.Entities;

public sealed class BankAccount : Account
{
    public BankCode Bank { get; private set; }

    private BankAccount()
    {
        
    }

    public BankAccount(string name, string accountNumber, BankCode bankCode, CurrencyCode currency, DateTime openedDate, decimal openingBalance, DateTime now, bool isElegibleForPayments)
        : base(name, AccountType.Asset, accountNumber, currency, openedDate, openingBalance, now, isElegibleForPayment: isElegibleForPayments)
    {
        Bank = bankCode;
    }
}

