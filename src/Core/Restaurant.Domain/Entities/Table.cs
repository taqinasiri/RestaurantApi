namespace Restaurant.Domain.Entities;

[Table("Tables")]
[Index(nameof(Title),IsUnique = true)]
[Index(nameof(Slug),IsUnique = true)]
public class Table : EntityBase
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Slug { get; set; } = null!;

    [MaxLength(2000)]
    public string? Description { get; set; }

    [Required]
    public byte Space { get; set; }

    [Required]
    public int RentalMinutePrice { get; set; }

    public bool IsAvailable { get; set; }
    public long BranchId { get; set; }

    #region Relations

    public Branch Branch { get; set; } = null!;
    public ICollection<ImageToTable>? Images { get; set; }

    #endregion Relations
}