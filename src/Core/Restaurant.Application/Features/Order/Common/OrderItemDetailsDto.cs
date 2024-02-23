namespace Restaurant.Application.Features.Order.Common;
public record OrderItemDetailsDto(long Id,string UnitPrice,string Amount)
{
    public string Title { get; set; } = null!;
}