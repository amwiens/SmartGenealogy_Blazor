using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartGenealogy.Infrastructure.Persistence.Configurations;

#nullable disable

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
        builder.Ignore(e => e.DomainEvents);
    }
}