using Expenses.Domain.Accounts;
using Expenses.Infrastructure.Persistence;
using SharedKernel.Domain.Enums;
namespace Api;

public static class SeedStaging
{
    public static void SeedData(ExpensesDbContext expensesDbContext)
    {
        if (!expensesDbContext.PaymentAccounts.Any())
            expensesDbContext.PaymentAccounts.AddRange(PaymentAccounts());

        expensesDbContext.SaveChanges();
    }

    private static PaymentAccount[] PaymentAccounts()
    {
        return new PaymentAccount[]
        {
            new(Guid.NewGuid(), "Cash", PaymentMethod.CASH, string.Empty, new[]{CurrencyCode.DOP}, null, null),
            new(Guid.NewGuid(), "Infinia Popular", PaymentMethod.CREDIT_CARD, "5415996673367998", new[] {CurrencyCode.DOP}, BankCode.BPD, PaymentNetwork.MasterCard),
            new(Guid.NewGuid(), "Visa Popular", PaymentMethod.CREDIT_CARD, "4921062595941897", new[] {CurrencyCode.DOP}, BankCode.BPD, PaymentNetwork.VISA),
            new(Guid.NewGuid(), "Visa Bravo", PaymentMethod.CREDIT_CARD, "4003081012454053", new[] {CurrencyCode.DOP, CurrencyCode.USD}, BankCode.SBD, PaymentNetwork.VISA),
            new(Guid.NewGuid(), "Cuenta Popular", PaymentMethod.BANK_ACCOUNT, "804015204", new[] {CurrencyCode.DOP}, BankCode.BPD, null),
            new(Guid.NewGuid(), "AMEX Gold", PaymentMethod.CREDIT_CARD, "377881247318783", new[] {CurrencyCode.DOP, CurrencyCode.USD}, BankCode.SBD, PaymentNetwork.AMEX),
            new(Guid.NewGuid(), "Cuenta Banreservas", PaymentMethod.BANK_ACCOUNT, "9603076683", new[] {CurrencyCode.DOP}, BankCode.BRD, null),
        };
    }
}
