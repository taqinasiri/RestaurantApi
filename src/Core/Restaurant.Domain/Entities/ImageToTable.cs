namespace Restaurant.Domain.Entities;

public class ImageToTable : IAuditableEntity
{
    public long ImageId { get; set; }
    public long TableId { get; set; }

    #region Relations

    public Image Image { get; set; } = null!;
    public Table Table { get; set; } = null!;

    #endregion Relations
}