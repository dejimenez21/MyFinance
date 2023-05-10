using Application.Domain.Enums;
using Domain.Enums;
using SharedKernel.Domain.Enums;
using SharedKernel.Infrastructure;

namespace Domain.Entities;

public sealed class BankAccount : Account
{
    public BankCode Bank { get; private set; }

    private BankAccount()
    {
        
    }

    public BankAccount(string name, string accountNumber, BankCode bankCode, CurrencyCode currency, DateTimeOffset openedDate, decimal openingBalance, DateTimeOffset now, bool isElegibleForPayments)
        : base(name, AccountType.Asset, accountNumber, currency, openedDate, openingBalance, now, isElegibleForPayment: isElegibleForPayments)
    {
        Bank = bankCode;
    }
}

