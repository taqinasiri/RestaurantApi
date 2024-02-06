namespace Restaurant.Application.Features.Branch.Requests.Commands;

public class CreateBranchCommand : IRequest
{
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Description { get; set; }
    public List<string>? ImagesBase64 { get; set; }
}