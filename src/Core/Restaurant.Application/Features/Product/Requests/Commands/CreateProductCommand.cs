namespace Restaurant.Application.Features.Product.Requests.Commands;

public class CreateProductCommand : IRequest
{
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Description { get; set; }
    public List<string>? ImagesBase64 { get; set; }
    public List<long>? CategoryIds { get; set; }
}