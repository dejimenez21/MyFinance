using FinancialTools.Domain.CashAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace FinancialTools.Infrastructure.Persistence.Configurations;

internal class CashAccountConfiguration : IEntityTypeConfiguration<CashAccount>
{
    public void Configure(EntityTypeBuilder<CashAccount> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedNever();

        builder.Property(b => b.Currency)
            .HasConversion(currency => currency.ToString(), value => Enum.Parse<CurrencyCode>(value));
    }
}
