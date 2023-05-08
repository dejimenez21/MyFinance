using Expenses.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Expenses.Infrastructure.Persistence.Configuration
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

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

            builder.Property(x => x.Category)
                .HasConversion(
                    category => category.ToString(),
                    value => Enumeration.FromName<ExpenseCategory>(value));
        }
    }
}
