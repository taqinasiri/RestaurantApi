namespace Restaurant.Domain.Entities;

[Table("Branches")]
public class Branch : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = null!;

    [Column(TypeName = "ntext")]
    [MaxLength(5000)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; } = null!;

    #region Relations

    public ICollection<ImageToBranch>? Images { get; set; }
    public ICollection<ProductToBranch>? Products { get; set; }

    #endregion Relations
}