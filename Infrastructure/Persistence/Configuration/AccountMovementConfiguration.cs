using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace Infrastructure.Persistence.Configuration
{
    internal class AccountMovementConfiguration : IEntityTypeConfiguration<AccountMovement>
    {
        public void Configure(EntityTypeBuilder<AccountMovement> builder)
        {
            builder.OwnsOne(am => am.Amount, money =>
            {
                money.Property(m => m.Value)
                    .HasColumnName("Amount")
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                money.Property(m => m.Currency)
                    .HasConversion(c => c.ToString(), s => Enum.Parse<CurrencyCode>(s))
                    .HasColumnName("Currency")
                    .IsRequired();
            });
        }
    }
}
