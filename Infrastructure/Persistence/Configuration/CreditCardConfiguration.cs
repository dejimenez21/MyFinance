using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(cc => cc.Bank)
            .HasConversion(bank => bank.ToString(), value => Enum.Parse<BankCode>(value));

        builder.Property(cc => cc.Network)
            .HasConversion(network => network.ToString(), value => Enum.Parse<PaymentNetwork>(value));
    }
}
