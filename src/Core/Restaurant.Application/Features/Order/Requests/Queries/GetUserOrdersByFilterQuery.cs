using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Requests.Queries;

public class GetUserOrdersByFilterQuery : IRequest<GetUserOrdersByFilterResponse>
{
    public long UserId { get; set; }
    public OrderingModel<OrderOrdering>? Ordering { get; set; } = new(OrderOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public OrderFilters Filters { get; set; } = new();
}

#region Filter

public enum OrderOrdering
{
    Default, TotalPrice, PayDateTime
}

public record OrderFilters(int? FromPrice = null,int? ToPrice = null,DateTime? FromDateTime = null,DateTime? ToDateTime = null)
{
    public List<long>? CategoryIds { get; set; }
    public List<long>? AvailableInBranchIds { get; set; }
};

#endregion Filter

#region Response

public record class GetUserOrdersByFilterResponse
{
    public List<OrderForUserFilterList>? Orders { get; set; }
    public PagingResponse Paging { get; set; }
}
public record OrderForUserFilterList(long Id,int TotalPrice,OrderStatus Status,DateTime FromTime,DateTime ToTime,DateTime? PayDateTime);

#endregion Response