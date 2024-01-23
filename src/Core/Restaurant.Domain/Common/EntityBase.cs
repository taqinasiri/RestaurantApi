namespace Restaurant.Domain.Common;

public abstract class EntityBase : IAuditableEntity
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}