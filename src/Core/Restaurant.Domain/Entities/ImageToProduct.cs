namespace Restaurant.Domain.Entities;

public class ImageToProduct : IAuditableEntity
{
    public long ImageId { get; set; }
    public long ProductId { get; set; }

    #region Relations

    public Image Image { get; set; } = null!;
    public Product Product { get; set; } = null!;

    #endregion Relations
}