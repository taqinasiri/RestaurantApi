namespace Restaurant.Application.Features.Table.Requests.Commands;

public class UpdateTableCommand : IRequest
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public byte Space { get; set; }
    public int RentalMinutePrice { get; set; }
    public string? Description { get; set; }
    public List<string>? NewImagesBase64 { get; set; }
    public List<string>? RemoveImageNames { get; set; }
}