﻿using FinancialTools.Domain.Common;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.BankAccounts;

public class BankAccount : AggregateRoot
{
    public string Name { get; set; }
    public string Number { get; set; }
    public BankCode Bank { get; set; }
    public CurrencyCode Currency { get; set; }
    public BankAccountType Type { get; set; }
    public DateTime OpenedDate { get; set; }
    public CardDetails? DebitCard { get; set; }

    public BankAccount(string name, string number, BankCode bank, CurrencyCode currency, BankAccountType type, CardDetails debitCard)
    {
        Id = Guid.NewGuid();
        Name = name;
        Number = number;
        Bank = bank;
        Currency = currency;
        Type = type;
        DebitCard = debitCard;
    }

    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private BankAccount() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}
