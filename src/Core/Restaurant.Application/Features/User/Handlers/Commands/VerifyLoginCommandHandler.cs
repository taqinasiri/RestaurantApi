using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Application.Features.User.Handlers.Commands;

public class VerifyLoginCommandHandler(IApplicationUserManager userManager,IJwtService jwtService) : IRequestHandler<VerifyLoginCommand,VerifyLoginResponse>
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly IJwtService _jwtService = jwtService;

    public async Task<VerifyLoginResponse> Handle(VerifyLoginCommand request,CancellationToken cancellationToken)
    {
        string phoneNumberOrEmail = request.PhoneNumberOrEmail;
        bool isEmail = phoneNumberOrEmail.IsEmail();

        var user = (isEmail ?
            await _userManager.FindByEmailAsync(phoneNumberOrEmail) :
            await _userManager.FindByPhoneNumber(phoneNumberOrEmail))
            ?? throw new NotFoundException("User");

        bool isVerify = await _userManager.VerifyChangePhoneNumberTokenAsync(user,request.Code,phoneNumberOrEmail);
        if(!isVerify)
        {
            throw new BadRequestException([Messages.Errors.CodeNotValid]);
        }

        var token = await _jwtService.Generate(user);
        return new(token);
    }
}