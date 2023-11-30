using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negotation.Domain.Entities;
using Negotation.Domain.Entities.Utils;
using Negotation.Domain.ValueObjects;

namespace Negotation.Infrastructure.DAL.Configurations;

internal class NegotiationConfiguration : IEntityTypeConfiguration<Negotiation>
{
    public void Configure(EntityTypeBuilder<Negotiation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new NegotiationId(x));

        builder.Property(x => x.ProposedPrice)
            .IsRequired()
            .HasConversion(x => x.Value, x => new NegotiationPrice(x));

        builder.HasOne(x => x.Product)
            .WithOne()
            .HasForeignKey<Negotiation>(x => x.ProductId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Negotiations)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Status)
            .HasConversion(x => x.ToString(), x => (Status)Enum.Parse(typeof(Status), x))
            .IsRequired();

        
    }
}
