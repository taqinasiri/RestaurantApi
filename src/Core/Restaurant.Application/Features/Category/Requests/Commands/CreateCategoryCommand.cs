namespace Restaurant.Application.Features.Category.Requests.Commands;

public class CreateCategoryCommand : IRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Slug { get; set; } = null!;
    public string PictureBase64 { get; set; } = null!;
    public long? ParentId { get; set; }
}