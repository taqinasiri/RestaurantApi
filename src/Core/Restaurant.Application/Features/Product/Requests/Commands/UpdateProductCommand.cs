namespace Restaurant.Application.Features.Product.Requests.Commands;

public class UpdateProductCommand : IRequest
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? Description { get; set; }
    public int Price { get; set; }
    public List<string>? NewImagesBase64 { get; set; }
    public List<string>? RemoveImageNames { get; set; }
    public List<long>? CategoryIds { get; set; }
}