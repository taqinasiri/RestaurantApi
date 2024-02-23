using Restaurant.Application.Features.Order.Common;

namespace Restaurant.Application.Features.Order.Requests.Commands;

public class CreateOrderCommand : IRequest<CreateOrderCommandResponse>
{
    public long UserId { get; set; }
    public long TableId { get; set; }
    public DateTime FromTime { get; set; }
    public DateTime ToTime { get; set; }
    public string? Description { get; set; }
    public List<OrderItemsDto> Items { get; set; } = null!;
}

public record CreateOrderCommandResponse(int TotalPrice);