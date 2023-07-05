using Application.Domain.Enums;
using Domain.Entities;
using Expenses.Domain.Accounts;
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
        if (!expensesContext.ExpenseGroups.Any())
            expensesContext.ExpenseGroups.AddRange(ExpensesGroups());

        if (!expensesContext.PaymentAccounts.Any())
            expensesContext.PaymentAccounts.AddRange(PaymentAccounts());

        var expensesSeeder = new ExpensesDataSeeder(expensesContext);
        expensesSeeder.SeedDataAsync().Wait();

        if (!transactionsContext.Accounts.Any())
        {
            var cashAccount = new Account("Cash", AccountType.Asset, "0000000001", CurrencyCode.DOP);
            var defaultExpenseAccount = new Account(AccountType.Expense.DefaultAccountName, AccountType.Expense, "EXP00000000004", CurrencyCode.DOP);
            transactionsContext.Accounts.AddRange(new[] { cashAccount, defaultExpenseAccount });
        }

        //if (!transactionsContext.CreditCards.Any())
        //    transactionsContext.CreditCards.AddRange(CreditCards());

        //if (!transactionsContext.BankAccounts.Any())
        //    transactionsContext.BankAccounts.AddRange(BankAccounts());

        transactionsContext.SaveChanges();
        expensesContext.SaveChanges();
    }

    private static PaymentAccount[] PaymentAccounts()
    {
        return new PaymentAccount[]
        {
            new(Guid.NewGuid(), "Cash", PaymentMethod.CASH, string.Empty, new[]{CurrencyCode.DOP}, null, null),
            new(Guid.NewGuid(), "Infinia Popular", PaymentMethod.CREDIT_CARD, "5415996673367998", new[] {CurrencyCode.DOP}, BankCode.BPD, PaymentNetwork.MasterCard),
            new(Guid.NewGuid(), "Visa Bravo", PaymentMethod.CREDIT_CARD, "4003081012454053", new[] {CurrencyCode.DOP, CurrencyCode.USD}, BankCode.SBD, PaymentNetwork.VISA),
            new(Guid.NewGuid(), "Cuenta Popular", PaymentMethod.BANK_ACCOUNT, "804015204", new[] {CurrencyCode.DOP}, BankCode.BPD, null)
        };
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

    //private static List<CreditCard> CreditCards()
    //{
    //    return new List<CreditCard>
    //    {
    //        new("Infinia Popular", BankCode.BPD, "8040152044645397", PaymentNetwork.VISA, CurrencyCode.DOP, DateTime.Now, DateTime.Now),
    //        new("Bravo Banreservas", BankCode.BRD, "9601452487456436", PaymentNetwork.MasterCard, CurrencyCode.DOP, DateTime.Now, DateTime.Now),
    //    };
    //}

    //private static List<BankAccount> BankAccounts()
    //{
    //    return new List<BankAccount>
    //    {
    //        new("Ahorros Popular", "804015204", BankCode.BPD, CurrencyCode.DOP, DateTime.Now, 1451, DateTime.Now, true),
    //        new("Corriente Banreservas", "960145248", BankCode.BRD, CurrencyCode.DOP, DateTime.Now, 25400, DateTime.Now, true)
    //    };
    //}
}
