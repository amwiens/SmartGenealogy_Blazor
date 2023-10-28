using System.Text.Json;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SmartGenealogy.Application.Common.Interfaces.Serialization;

namespace SmartGenealogy.Infrastructure.Persistence.Configurations;

#nullable disable

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Ignore(e => e.DomainEvents);
        builder.Property(e => e.Pictures)
            .HasConversion(
                v => JsonSerializer.Serialize(v, DefaultJsonSerializerOptions.Options),
                v => JsonSerializer.Deserialize<List<ProductImage>>(v, DefaultJsonSerializerOptions.Options),
                new ValueComparer<List<ProductImage>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));
    }
}