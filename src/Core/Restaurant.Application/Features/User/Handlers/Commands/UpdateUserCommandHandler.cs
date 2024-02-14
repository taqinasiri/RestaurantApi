using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Application.Features.User.Handlers.Commands;

public class UpdateUserCommandHandler(IApplicationUserManager userManager) : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationUserManager _userManager = userManager;

    public async Task Handle(UpdateUserCommand request,CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString()) ?? throw new NotFoundException("User");
        user.UserName = request.UserName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        user.IsActive = request.IsActive;
        await _userManager.UpdateAsync(user);
    }
}