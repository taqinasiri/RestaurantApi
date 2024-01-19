using Microsoft.Extensions.Options;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Exceptions;
using Restaurant.Application.Extensions;
using Restaurant.Application.Features.User.Requests.Commands;
using Restaurant.Application.Helpers;
using Restaurant.Application.Models;

namespace Restaurant.Application.Features.User.Handlers.Commands;

internal class LoginRegisterCommandHandler(IApplicationUserManager userManager,IOptionsSnapshot<SiteSettings> options) : IRequestHandler<LoginRegisterCommand,LoginRegisterResponse>
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly SiteSettings _siteSettings = options.Value;

    public async Task<LoginRegisterResponse> Handle(LoginRegisterCommand request,CancellationToken cancellationToken)
    {
        string phoneNumberOrEmail = request.PhoneNumberOrEmail;
        bool isEmail = phoneNumberOrEmail.IsEmail();

        var user = isEmail ?
            await _userManager.FindByEmailAsync(phoneNumberOrEmail) :
            await _userManager.FindByPhoneNumber(phoneNumberOrEmail);

        if(user is not null)
        {
            if(isEmail)
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.Email!);
                //TODO : Send Email
            }
            else
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.PhoneNumber!);
                //TODO : Send SMS
            }

            return new(phoneNumberOrEmail);
        }

        if(isEmail)
        {
            user = new()
            {
                UserName = phoneNumberOrEmail.Split('@')[0],
                Email = phoneNumberOrEmail,
                Avatar = _siteSettings.UserDefaultAvatar
            };
            var result = await _userManager.CreateAsync(user);
            if(!result.Succeeded)
            {
                throw new BadRequestException(result.GetErrors());
            }

            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.Email);
            //TODO : Send Email
        }
        else
        {
            user = new()
            {
                UserName = phoneNumberOrEmail,
                PhoneNumber = phoneNumberOrEmail,
                Avatar = _siteSettings.UserDefaultAvatar,
                Email = $"{StringHelper.GenerateGuid()}@test.com"
            };
            var result = await _userManager.CreateAsync(user);
            if(!result.Succeeded)
            {
                throw new BadRequestException(result.GetErrors());
            }
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.PhoneNumber);
            //TODO : Send SMS
        }

        return new(phoneNumberOrEmail);
    }
}