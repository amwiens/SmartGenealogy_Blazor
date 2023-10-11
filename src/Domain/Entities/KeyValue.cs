using SmartGenealogy.Domain.Enums;

namespace SmartGenealogy.Domain.Entities;

public class KeyValue : BaseAuditableEntity, IAuditTrail
{
    public Picklist Name { get; set; } = Picklist.Brand;

    public string? Value { get; set; }

    public string? Text { get; set; }

    public string? Description { get; set; }
}