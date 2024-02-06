namespace Restaurant.Application.Features.Branch.Requests.Queries;

public class GetBranchesByFilterQuery : IRequest<GetBranchesByFilterResponse>
{
    public OrderingModel<BranchOrdering> Ordering { get; set; } = new(BranchOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public BranchFilters Filters { get; set; } = new();
}

#region Filters

public enum BranchOrdering
{
    Default, Title, Slug
}

public record BranchFilters(string? Title = null,string? Slug = null,string? Address = null);

#endregion Filters

#region Response

public class GetBranchesByFilterResponse
{
    public List<BranchForFilterList>? Branches { get; set; }
    public PagingResponse? Paging { get; set; }
}

public record BranchForFilterList(long Id,string Title,string Slug,string Address);

#endregion Response