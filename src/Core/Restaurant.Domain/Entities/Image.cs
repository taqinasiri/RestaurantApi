namespace Restaurant.Domain.Entities;

[Table("Images")]
[Index(nameof(Name),IsUnique = true)]
public class Image : EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [MaxLength(10)]
    public string? Extension { get; set; }

    public int? Size { get; set; }

    [Required]
    public DateTime UploadDate { get; set; }

    #region Relations

    public ICollection<ImageToProduct>? Products { get; set; }
    public ICollection<ImageToBranch>? Branches { get; set; }
    public ICollection<ImageToTable>? Tables { get; set; }

    #endregion Relations
}