namespace Restaurant.Application.Features.User.Requests.Queries;

public class GetUserDetailsQuery(long id) : IRequest<GetUserDetailsResponse>
{
    public long Id { get; set; } = id;
}

public record GetUserDetailsResponse(long Id,string UserName,string Email,string PhoneNumber,string Avatar,bool IsActive);