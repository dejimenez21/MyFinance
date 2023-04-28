using Expenses.Domain.ExpenseGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Expenses.Infrastructure.Persistence.Configuration
{
    internal class ExpenseGroupConfiguration : IEntityTypeConfiguration<ExpenseGroup>
    {
        public void Configure(EntityTypeBuilder<ExpenseGroup> builder)
        {
            builder.HasMany(g => g.Expenses)
                .WithOne()
                .HasForeignKey(e => e.GroupId)
                .Metadata.PrincipalToDependent?.SetField("_expenses");

            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
