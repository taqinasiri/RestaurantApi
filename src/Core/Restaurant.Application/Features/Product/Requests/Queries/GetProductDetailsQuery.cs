using Restaurant.Application.Features.Product.Common;

namespace Restaurant.Application.Features.Product.Requests.Queries;

public class GetProductDetailsQuery(int id) : IRequest<GetProductDetailsResponse>, ICacheableMediatrQuery
{
    public int Id { get; set; } = id;

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.ProductDetails;
    public string CacheKey => $"{CacheKeys.Product}-{Id}";
}

public record class GetProductDetailsResponse(long Id,string Title,string? Description,string Slug,int Price)
{
    public List<string>? Images { get; set; }
    public List<CategoryForProductDto>? Categories { get; set; }
    public List<BranchForProductDto>? Branches { get; set; }
}