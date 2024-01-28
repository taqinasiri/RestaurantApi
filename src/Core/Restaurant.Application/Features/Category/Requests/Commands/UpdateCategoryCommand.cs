namespace Restaurant.Application.Features.Category.Requests.Commands;

public class UpdateCategoryCommand : IRequest
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Slug { get; set; } = null!;
    public string? PictureBase64 { get; set; }
    public long? ParentId { get; set; }
}