using Expenses.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace Expenses.Infrastructure.Persistence.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<PaymentAccount>
{
    public void Configure(EntityTypeBuilder<PaymentAccount> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(a => a.Method).HasConversion(m => m.ToString(), value => Enum.Parse<PaymentMethod>(value));
        builder.Property(a => a.Network).HasConversion(n => n.ToString(), value => value != null ? Enum.Parse<PaymentNetwork>(value) : null);
        builder.Property(a => a.Bank).HasConversion(b => b.ToString(), value => value != null ? Enum.Parse<BankCode>(value) : null);
        builder.Property(a => a.Currencies).HasConversion(c => string.Join('|', c.Select(e => e.ToString())), value => value.Split('|', StringSplitOptions.TrimEntries).Select(x => Enum.Parse<CurrencyCode>(x)).ToArray());
    }
}
