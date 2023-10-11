using SmartGenealogy.Domain.Enums;

namespace SmartGenealogy.Domain.Entities;

public class Document : OwnerPropertyEntity, IMayHaveTenant, IAuditTrail
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public JobStatus Status { get; set; } = default!;

    public string? Content { get; set; }

    public bool IsPublic { get; set; }

    public string? URL { get; set; }

    public DocumentType DocumentType { get; set; } = default!;

    public string? TenantId { get; set; }

    public virtual Tenant? Tenant { get; set; }
}