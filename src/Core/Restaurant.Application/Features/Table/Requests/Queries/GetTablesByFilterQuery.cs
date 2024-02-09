using Restaurant.Application.Features.Table.Common;

namespace Restaurant.Application.Features.Table.Requests.Queries;

public class GetTablesByFilterQuery : IRequest<GetTablesByFilterResponse>
{
    public OrderingModel<TableOrdering>? Ordering { get; set; } = new(TableOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public TableFilters Filters { get; set; } = new();
}

#region Filter

public enum TableOrdering
{
    Default, Title, Slug, Space, Branch
}

public record TableFilters(string? Title = null,string? Slug = null,byte? Space = null,bool? IsAvailable = null,int? BranchId = null);

#endregion Filter

#region Response

public record GetTablesByFilterResponse
{
    public List<TableForFilterList>? Tables { get; set; }
    public PagingResponse Paging { get; set; }
}
public record TableForFilterList(long Id,string Title,string Slug,byte Space,bool IsAvailable,BranchForTableDto Branch);

#endregion Response