namespace Restaurant.Domain.Entities;

public class ProductToBranch : IAuditableEntity
{
    public long ProductId { get; set; }
    public long BranchId { get; set; }

    public bool IsAvailable { get; set; }
    public bool IsActive { get; set; }

    #region Relations

    public Product Product { get; set; } = null!;
    public Branch Branch { get; set; } = null!;

    #endregion Relations
}