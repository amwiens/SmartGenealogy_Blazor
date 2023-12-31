﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartGenealogy.Infrastructure.Persistence.Configurations;

public class KeyConfiguration : IEntityTypeConfiguration<KeyValue>
{
    public void Configure(EntityTypeBuilder<KeyValue> builder)
    {
        builder.Property(t => t.Name).HasConversion<string>();
        builder.Ignore(e => e.DomainEvents);
    }
}