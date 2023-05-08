﻿using Application.Domain.Enums;
using Domain.Entities;
using Domain.Enums;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using Expenses.Infrastructure.Persistence;
using Infrastructure;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.ValueObjects;

namespace Api;

public static class Seed
{
    public static void SeedData(TransactionsDbContext transactionsContext, ExpensesDbContext expensesContext)
    {
        if (!expensesContext.Expenses.Any())
            expensesContext.Expenses.AddRange(Expenses());

        if (!expensesContext.ExpenseGroups.Any())
            expensesContext.ExpenseGroups.AddRange(ExpensesGroups());

        if (!transactionsContext.Accounts.Any())
        {
            var cashAccount = new Account("Cash", AccountType.Asset, "0000000001", CurrencyCode.DOP, DateTime.Now, 1245, true, true);
            var defaultExpenseAccount = new Account(AccountType.Expense.DefaultAccountName, AccountType.Expense, "EXP00000000004", CurrencyCode.DOP, DateTime.Now, 0);
            transactionsContext.Accounts.AddRange(new[] { cashAccount, defaultExpenseAccount });
        }

        if (!transactionsContext.CreditCards.Any())
            transactionsContext.CreditCards.AddRange(CreditCards());

        if (!transactionsContext.BankAccounts.Any())
            transactionsContext.BankAccounts.AddRange(BankAccounts());

        transactionsContext.SaveChanges();
        expensesContext.SaveChanges();
    }

    private static List<Expense> Expenses()
    {
        return new List<Expense>()
        {
            new(new Money(500, CurrencyCode.DOP), "Supermercado", DateTime.Now, ExpenseCategory.FoodAndGroceries, Guid.NewGuid(), Guid.NewGuid()),
            new(new Money(300, CurrencyCode.DOP), "Otra cosa", DateTime.Now, ExpenseCategory.FoodAndGroceries, Guid.NewGuid(), Guid.NewGuid()),
            new(new Money(25000, CurrencyCode.DOP), "Acondicionador de Aire", DateTime.Now, ExpenseCategory.FoodAndGroceries, Guid.NewGuid(), Guid.NewGuid()),
            new(new Money(1250, CurrencyCode.DOP), "Balon de futbol", DateTime.Now, ExpenseCategory.FoodAndGroceries, Guid.NewGuid(), Guid.NewGuid())
        };

    }

    private static List<ExpenseGroup> ExpensesGroups()
    {
        return new List<ExpenseGroup>()
        {
            new ExpenseGroup("Home", "Expenses made for home", Guid.NewGuid()),
            new ExpenseGroup("New Job", "Expenses made for the new Job Project", Guid.NewGuid()),
        };
    }

    private static List<CreditCard> CreditCards()
    {
        return new List<CreditCard>
        {
            new("Infinia Popular", BankCode.BPD, "8040152044645397", PaymentNetwork.VISA, CurrencyCode.DOP, DateTime.Now),
            new("Bravo Banreservas", BankCode.BRD, "9601452487456436", PaymentNetwork.MasterCard, CurrencyCode.DOP, DateTime.Now),
        };
    }

    private static List<BankAccount> BankAccounts()
    {
        return new List<BankAccount>
        {
            new("Ahorros Popular", "804015204", BankCode.BPD, CurrencyCode.DOP, DateTime.Now, 1451, true),
            new("Corriente Banreservas", "960145248", BankCode.BRD, CurrencyCode.DOP, DateTime.Now, 25400, true)
        };
    }
}
