namespace Restaurant.Domain.Entities;

public class ImageToBranch : IAuditableEntity
{
    public long ImageId { get; set; }
    public long BranchId { get; set; }

    #region Relations

    public Image Image { get; set; } = null!;
    public Branch Branch { get; set; } = null!;

    #endregion Relations
}