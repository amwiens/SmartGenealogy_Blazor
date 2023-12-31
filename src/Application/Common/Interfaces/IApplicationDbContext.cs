﻿using Microsoft.EntityFrameworkCore.ChangeTracking;

using SmartGenealogy.Domain.Entities.Logger;

namespace SmartGenealogy.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Logger> Loggers { get; set; }

    DbSet<AuditTrail> AuditTrails { get; set; }

    DbSet<Document> Documents { get; set; }

    DbSet<KeyValue> KeyValues { get; set; }

    DbSet<Product> Products { get; set; }

    DbSet<Tenant> Tenants { get; set; }

    DbSet<Customer> Customers { get; set; }

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}