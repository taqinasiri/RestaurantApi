using Restaurant.Application.Features.Order.Common;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Requests.Queries;

public class GetUserOrderDetailsQuery : IRequest<GetUserOrderDetailsQueryResponse>
{
    public long UserId { get; set; }
    public long OrderId { get; set; }
}

public record GetUserOrderDetailsQueryResponse(long Id,
    int TotalPrice,
    OrderStatus Status,
    DateTime FromTime,
    DateTime ToTime,
    string Description,
    int RefId,
    long TableId,
    string TableTitle,
    int TableRentalMinutePrice,
    DateTime? PayDateTime)
{
    public List<OrderItemDetailsDto> Items { get; set; } = null!;
};