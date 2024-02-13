using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Application.Features.User.Handlers.Queries;

public class GetUserDetailsQueryHandler(IApplicationUserManager userManager) : IRequestHandler<GetUserDetailsQuery,GetUserDetailsResponse>
{
    private readonly IApplicationUserManager _userManager = userManager;

    public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request,CancellationToken cancellationToken)
    {
        var result = await _userManager.GetDetailsById(request.Id) ?? throw new NotFoundException("User");
        return result;
    }
}