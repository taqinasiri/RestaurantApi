namespace Restaurant.Application.Features.Table.Requests.Commands;

public class CreateTableCommand : IRequest
{
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public byte Space { get; set; }
    public int RentalMinutePrice { get; set; }
    public long BranchId { get; set; }
    public string? Description { get; set; }
    public List<string>? ImagesBase64 { get; set; }
}