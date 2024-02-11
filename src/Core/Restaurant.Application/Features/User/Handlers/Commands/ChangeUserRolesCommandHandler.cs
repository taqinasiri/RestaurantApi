using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Application.Features.User.Handlers.Commands;

public class ChangeUserRolesCommandHandler(
    IApplicationUserManager userManager,
    IApplicationRoleManager roleManager) : IRequestHandler<ChangeUserRolesCommand>
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly IApplicationRoleManager _roleManager = roleManager;

    public async Task Handle(ChangeUserRolesCommand request,CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString()) ?? throw new NotFoundException("User");
        bool isExitsNewRoles = await _roleManager.IsExitsRoles(request.NewRoles);
        if(!isExitsNewRoles)
        {
            throw new NotFoundException("Roles");
        }
        await _userManager.AddToRolesAsync(user,request.NewRoles);
        await _userManager.RemoveFromRolesAsync(user,request.RemoveRoles);
    }
}