using FinancialTools.Domain.BankAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace FinancialTools.Infrastructure.Persistence.Configurations;

internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedNever();

        builder.Property(ba => ba.Bank)
            .HasConversion(bank => bank.ToString(), value => Enum.Parse<BankCode>(value));

        builder.Property(b => b.Currency)
            .HasConversion(currency => currency.ToString(), value => Enum.Parse<CurrencyCode>(value));

        builder.Property(b => b.Type)
            .HasConversion(type => type.ToString(), value => Enum.Parse<BankAccountType>(value));

        builder.OwnsOne(b => b.DebitCard, ob =>
        {
            ob.OwnsOne(c => c.ExpirationDate);
        });
    }
}
