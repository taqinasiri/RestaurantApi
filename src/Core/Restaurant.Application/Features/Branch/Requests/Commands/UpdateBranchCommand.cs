namespace Restaurant.Application.Features.Branch.Requests.Commands;

public class UpdateBranchCommand : IRequest
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Description { get; set; }
    public long? AdminId { get; set; }
    public List<string>? NewImagesBase64 { get; set; }
    public List<string>? RemoveImageNames { get; set; }
}