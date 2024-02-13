using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User,GetUserDetailsResponse>();
    }
}