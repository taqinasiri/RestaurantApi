using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User,GetUserDetailsResponse>()
            .ForMember(dest => dest.Roles,options => options.MapFrom(src => src.UserRoles.Select(r => r.Role.Name)));
        CreateMap<User,UserForFilterList>();
    }
}