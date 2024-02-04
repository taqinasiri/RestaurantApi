namespace Restaurant.Domain.Entities;

public class CategoryToProduct : IAuditableEntity
{
    public long CategoryId { get; set; }
    public long ProductId { get; set; }

    #region Relations

    public Category Category { get; set; } = null!;
    public Product Product { get; set; } = null!;

    #endregion Relations
}