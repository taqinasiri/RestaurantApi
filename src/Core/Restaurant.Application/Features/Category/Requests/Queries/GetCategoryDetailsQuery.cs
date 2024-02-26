namespace Restaurant.Application.Features.Category.Requests.Queries;

public class GetCategoryDetailsQuery(int id) : IRequest<GetCategoryDetailsResponse>, ICacheableMediatrQuery
{
    public int Id { get; set; } = id;

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.CategoryDetails;
    public string CacheKey => $"{CacheKeys.Category}-{Id}";
}

public record class GetCategoryDetailsResponse(int Id,string Title,string? Description,string Slug,long? ParentId);