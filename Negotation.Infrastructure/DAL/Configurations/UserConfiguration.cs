using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;

namespace Negotation.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserId(x));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(x => x.Value, x => new UserName(x));

        /*builder.HasOne(x => x.Negotiation)
            .WithOne()
            .HasForeignKey<User>(e => e.NegotiationId)
            .IsRequired(false);*/
       
    }
}
