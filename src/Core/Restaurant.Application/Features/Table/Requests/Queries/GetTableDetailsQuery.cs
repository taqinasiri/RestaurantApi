using Restaurant.Application.Features.Table.Common;
using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Application.Features.Table.Requests.Queries;

public class GetTableDetailsQuery(long id) : IRequest<GetTableDetailsResponse>, ICacheableMediatrQuery
{
    public long Id { get; set; } = id;

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.OrderDetails;
    public string CacheKey => $"{CacheKeys.Table}-{Id}";
}

public record GetTableDetailsResponse(
    long Id,
    string Title,
    string Slug,
    string? Description,
    byte Space,
    int RentalMinutePrice,
    bool IsAvailable,
    BranchForTableDto Branch);