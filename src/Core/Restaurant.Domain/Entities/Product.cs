namespace Restaurant.Domain.Entities;

[Table("Products")]
[Index(nameof(Title),IsUnique = true)]
[Index(nameof(Slug),IsUnique = true)]
public class Product : EntityBase
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = null!;

    [Column(TypeName = "ntext")]
    [MaxLength(5000)]
    public string? Description { get; set; }

    #region Relations

    public ICollection<CategoryToProduct>? Categories { get; set; }
    public ICollection<ImageToProduct>? Images { get; set; }
    public ICollection<ProductToBranch>? Branches { get; set; }

    #endregion Relations
}