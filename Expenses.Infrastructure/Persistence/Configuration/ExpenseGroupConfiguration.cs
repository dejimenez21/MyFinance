using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expenses.Infrastructure.Persistence.Configuration
{
    internal class ExpenseGroupConfiguration : IEntityTypeConfiguration<ExpenseGroup>
    {
        public void Configure(EntityTypeBuilder<ExpenseGroup> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany<Expense>()
                .WithOne()
                .HasForeignKey(e => e.GroupId);
        }
    }
}
