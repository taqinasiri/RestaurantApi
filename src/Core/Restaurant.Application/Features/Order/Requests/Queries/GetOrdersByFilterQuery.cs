using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Requests.Queries;

public class GetOrdersByFilterQuery : IRequest<GetOrdersByFilterResponse>
{
    public long AdminId { get; set; }
    public bool IsMainAdmin { get; set; }
    public OrderingModel<OrderOrdering>? Ordering { get; set; } = new(OrderOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public OrderFilters Filters { get; set; } = new();
}

#region Filter

public enum OrderOrdering
{
    Default, TotalPrice, PayDateTime
}

public record OrderFilters(long? UserId = null,int? FromPrice = null,int? ToPrice = null,DateTime? FromDateTime = null,DateTime? ToDateTime = null)
{
    public List<long>? CategoryIds { get; set; }
    public List<long>? AvailableInBranchIds { get; set; }
};

#endregion Filter

#region Response

public record class GetOrdersByFilterResponse
{
    public List<OrderForFilterList>? Orders { get; set; }
    public PagingResponse Paging { get; set; }
}
public record OrderForFilterList(long Id,int TotalPrice,OrderStatus Status,DateTime FromTime,DateTime ToTime,DateTime? PayDateTime);

#endregion Response