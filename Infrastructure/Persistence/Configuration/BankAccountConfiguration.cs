using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel.Domain.Enums;

namespace Infrastructure.Persistence.Configuration;

internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(ba => ba.Bank)
            .HasConversion(bank => bank.ToString(), value => Enum.Parse<BankCode>(value));
    }
}
