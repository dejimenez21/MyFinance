using FinancialTools.Domain.CreditCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace FinancialTools.Infrastructure.Persistence.Configurations;

internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();

        builder.Property(c => c.Bank)
            .HasConversion(bank => bank.ToString(), value => Enum.Parse<BankCode>(value));

        builder.OwnsOne(b => b.CardInfo, ob =>
        {
            ob.OwnsOne(c => c.ExpirationDate);
        });

        builder.OwnsOne(c => c.StatementDate);

        builder.HasMany(c => c.Accounts)
            .WithOne()
            .HasForeignKey(a => a.CreditCardId)
            .Metadata.PrincipalToDependent?.SetField("_accounts");
    }
}
