using Application.Domain.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Infrastructure.Persistence.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.UseTptMappingStrategy();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(a => a.OpeningBalance).HasColumnType("decimal(18,2)");

            builder.Property(a => a.Type)
                .HasConversion(
                    type => type.ToString(),
                    value => Enumeration.FromName<AccountType>(value));

            builder.HasMany(a => a.AccountEntries)
                .WithOne()
                .HasForeignKey(a => a.AccountId)
                .Metadata.PrincipalToDependent?.SetField("_accountEntries"); 

            builder.Property(a => a.Currency)
                .HasConversion(currency => currency.ToString(), value => Enum.Parse<CurrencyCode>(value));
        }
    }
}
