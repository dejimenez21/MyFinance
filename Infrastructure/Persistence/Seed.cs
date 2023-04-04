using Application.Domain.Enums;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Persistence
{
    public static class Seed
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Expenses.Any()) 
                context.Expenses.AddRange(Expenses());

            if (!context.Accounts.Any())
            {
                var cashAccount = new Account("Cash", AccountType.Asset, "0000000001", CurrencyCode.DOP, DateTime.Now, 1245, true, true);
                context.Accounts.Add(cashAccount);
            }

            if (!context.CreditCards.Any()) 
                context.CreditCards.AddRange(CreditCards());

            if (!context.BankAccounts.Any())
                context.BankAccounts.AddRange(BankAccounts());

            if (!context.ChangeTracker.HasChanges()) return;

            context.SaveChanges();
        }

        private static List<Expense> Expenses()
        {
            return new List<Expense>()
            {
                new(500, "Supermercado"),
                new(300, "Otra cosa"),
                new(25000, "Acondicionador de Aire"),
                new(1250, "Balon de futbol")
            };

        }

        private static List<CreditCard> CreditCards()
        {
            return new List<CreditCard>
            {
                new("Infinia Popular", BankCode.BPD, "8040152044645397", PaymentNetwork.VISA),
                new("Bravo Banreservas", BankCode.BRD, "9601452487456436", PaymentNetwork.MasterCard),
            };
        }

        private static List<BankAccount> BankAccounts()
        {
            return new List<BankAccount>
            {
                new("Ahorros Popular", "804015204", BankCode.BPD),
                new("Corriente Banreservas", "960145248", BankCode.BRD)
            };
        }
    }
}
