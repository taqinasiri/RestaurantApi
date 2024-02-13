namespace Restaurant.Application.Features.User.Requests.Queries;

public class GetUsersByFilterQuery : IRequest<GetUsersByFilterResponse>
{
    public OrderingModel<UserOrdering>? Ordering { get; set; } = new(UserOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public UserFilters Filters { get; set; } = new();
}

#region Filters

public enum UserOrdering
{
    Default, UserName, Email, PhoneNumber
}

public record UserFilters(string? UserName = null,string? Email = null,string? PhoneNumber = null,bool? IsActive = null);

#endregion Filters

#region Response

public record class GetUsersByFilterResponse
{
    public List<UserForFilterList>? Users { get; set; }
    public PagingResponse Paging { get; set; }
}
public record UserForFilterList(long Id,string UserName,string Email,string PhoneNumber,string Avatar,bool IsActive);

#endregion Response