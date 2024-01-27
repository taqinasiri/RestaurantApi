namespace Restaurant.Application.Features.Category.Requests.Queries;

public class GetCategoriesByFilterQuery : IRequest<GetCategoriesByFilterResponse>
{
    public OrderingModel<CategoryOrdering> Ordering { get; set; } = new(CategoryOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public CategoryFilters Filters { get; set; } = new();
}

#region Filters

public enum CategoryOrdering
{
    Default, Title, Slug
}

public record CategoryFilters(string? Title = null,string? Slug = null,long? ParentId = null);

#endregion Filters

#region Response

public class GetCategoriesByFilterResponse
{
    public List<CategoryForFilterList>? Categories { get; set; }
    public PagingResponse? Paging { get; set; }
}

public record CategoryForFilterList(long Id,string Title,string Slug,string? ParentTitle);

#endregion Response