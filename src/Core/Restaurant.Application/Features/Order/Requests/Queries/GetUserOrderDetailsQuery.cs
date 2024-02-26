using Restaurant.Application.Features.Order.Common;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Requests.Queries;

public class GetUserOrderDetailsQuery : IRequest<GetUserOrderDetailsQueryResponse>, ICacheableMediatrQuery
{
    public long UserId { get; set; }
    public long OrderId { get; set; }

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.OrderDetails;
    public string CacheKey => $"{CacheKeys.Order}-{OrderId}-{UserId}";
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