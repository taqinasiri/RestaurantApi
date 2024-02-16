using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Entities;

[Table("Branches")]
[Index(nameof(Title),IsUnique = true)]
[Index(nameof(Slug),IsUnique = true)]
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

    public long AdminId { get; set; }

    #region Relations

    public ICollection<ImageToBranch>? Images { get; set; }
    public ICollection<ProductToBranch>? Products { get; set; }
    public ICollection<Table>? Tables { get; set; }
    public ICollection<BranchWorkingHours>? BranchWorkingHours { get; set; }
    public User Admin { get; set; } = null!;

    #endregion Relations
}