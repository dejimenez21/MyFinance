using FinancialTools.Domain.CreditCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace FinancialTools.Infrastructure.Persistence.Configurations;

internal class CreditCardAccountConfiguration : IEntityTypeConfiguration<CreditCardAccount>
{
    public void Configure(EntityTypeBuilder<CreditCardAccount> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedNever();

        builder.Property(b => b.Currency)
            .HasConversion(currency => currency.ToString(), value => Enum.Parse<CurrencyCode>(value));
    }
}
