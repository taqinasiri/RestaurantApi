namespace Restaurant.Application.Features.User.Requests.Queries;

public class GetUserDetailsQuery(long id) : IRequest<GetUserDetailsResponse>, ICacheableMediatrQuery
{
    public long Id { get; set; } = id;

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.UserDetails;
    public string CacheKey => $"{CacheKeys.User}-{Id}";
}

public record GetUserDetailsResponse(long Id,string UserName,string Email,string PhoneNumber,string Avatar,bool IsActive)
{
    public string[]? Roles { get; set; }
}