using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;

namespace Negotation.Infrastructure.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ProductId(x));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasConversion(x => x.Value, x => new ProductName(x));

        builder.Property(x => x.Price)
            .IsRequired()
            .HasConversion(x => x.Value, x => new ProductPrice(x));
    }
}
