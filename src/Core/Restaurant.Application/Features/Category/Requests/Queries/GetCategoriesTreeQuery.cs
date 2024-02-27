namespace Restaurant.Application.Features.Category.Requests.Queries;

public class GetCategoriesTreeQuery : IRequest<GetCategoriesTreeResponse>, ICacheableMediatrQuery
{
    public byte Depth { get; set; }

    public bool BypassCache { get; set; }
    public string CacheKey => $"{CacheKeys.CategoryTree}-{Depth}";
    public TimeSpan? SlidingExpiration { get; set; }
}

public record GetCategoriesTreeResponse()
{
    public List<CategoryForTree> Categories { get; set; } = [];
}
public record CategoryForTree(long Id,string Title,string Slug)
{
    public List<CategoryForTree>? SubCategories { get; set; }
};