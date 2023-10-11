using System.ComponentModel.DataAnnotations.Schema;

using SmartGenealogy.Domain.Identity;

namespace SmartGenealogy.Domain.Common;

public abstract class OwnerPropertyEntity : BaseAuditableEntity
{
    [ForeignKey("CreatedBy")]
    public virtual ApplicationUser? Owner { get; set; }

    [ForeignKey("LastModifiedBy")]
    public virtual ApplicationUser? Editor { get; set; }
}