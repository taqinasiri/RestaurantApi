namespace Restaurant.Domain.Entities;

[Table("Categories")]
[Index(nameof(Slug),IsUnique = true)]
[Index(nameof(Title),IsUnique = true)]
public class Category : EntityBase
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(4000)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = null!;

    [MaxLength(50)]
    public string? Picture { get; set; }

    public long? ParentId { get; set; }

    #region Relations

    [ForeignKey(nameof(ParentId))]
    public Category? Parent { get; set; }

    public ICollection<Category>? Children { get; set; }
    public ICollection<CategoryToProduct>? Products { get; set; }

    #endregion Relations
}