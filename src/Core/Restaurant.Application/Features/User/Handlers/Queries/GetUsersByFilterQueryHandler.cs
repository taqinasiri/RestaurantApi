using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Application.Features.User.Handlers.Queries;

public class GetUsersByFilterQueryHandler(IApplicationUserManager userManager) : IRequestHandler<GetUsersByFilterQuery,GetUsersByFilterResponse>
{
    public readonly IApplicationUserManager _userManager = userManager;

    public async Task<GetUsersByFilterResponse> Handle(GetUsersByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _userManager.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        var users = await _userManager.GetByFilterAsync(request.Filters,paging,request.Ordering);

        paging.ResultsCount = users.ResultsCount;

        return new()
        {
            Paging = paging,
            Users = users.Data
        };
    }
}