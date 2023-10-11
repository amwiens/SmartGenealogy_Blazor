using Microsoft.EntityFrameworkCore.ChangeTracking;

using SmartGenealogy.Domain.Enums;
using SmartGenealogy.Domain.Identity;

namespace SmartGenealogy.Domain.Entities.Audit;

public class AuditTrail : IEntity<int>
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public virtual ApplicationUser? Owner { get; set; }

    public AuditType AuditType { get; set; }

    public string? TableName { get; set; }

    public DateTime DateTime { get; set; }

    public Dictionary<string, object?>? OldValues { get; set; }

    public Dictionary<string, object?>? NewValues { get; set; }

    public List<string>? AffectedColumns { get; set; }

    public Dictionary<string, object> PrimaryKey { get; set; } = [];

    public List<PropertyEntry> TemporaryProperties { get; } = [];

    public bool HasTemporaryProperties => TemporaryProperties.Count != 0;
}