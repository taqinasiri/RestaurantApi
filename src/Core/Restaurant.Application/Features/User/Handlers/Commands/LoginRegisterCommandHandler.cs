using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Application.Features.User.Handlers.Commands;

internal class LoginRegisterCommandHandler(IApplicationUserManager userManager
    ,IOptionsSnapshot<SiteSettings> options,
    IEmailSenderService emailSender,
    ISmsSenderService smsSender) : IRequestHandler<LoginRegisterCommand,LoginRegisterResponse>
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly SiteSettings _siteSettings = options.Value;
    private readonly IEmailSenderService _emailSender = emailSender;
    private readonly ISmsSenderService _smsSender = smsSender;

    public async Task<LoginRegisterResponse> Handle(LoginRegisterCommand request,CancellationToken cancellationToken)
    {
        string phoneNumberOrEmail = request.PhoneNumberOrEmail;
        bool isEmail = phoneNumberOrEmail.IsEmail();
        DateTime sendCodeLastTime = DateTime.Now;

        var user = isEmail ?
            await _userManager.FindByEmailAsync(phoneNumberOrEmail) :
            await _userManager.FindByPhoneNumber(phoneNumberOrEmail);

        if(user is not null)
        {
            if(user.SendCodeLastTime > sendCodeLastTime.AddSeconds(-_siteSettings.WaitForSendCodeSeconds))
            {
                return new(phoneNumberOrEmail,_siteSettings.WaitForSendCodeSeconds,user.SendCodeLastTime);
            }
            await _userManager.UpdateSendCodeLastTime(user,sendCodeLastTime,true);
            if(isEmail)
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.Email!);
                var body = EmailTemplates.LoginCodeEmail(code,user.Email!);
                await _emailSender.SendEmailAsync(user.Email!,Messages.Subjects.LoginCodeMailSubject,body);
            }
            else
            {
                var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.PhoneNumber!);
                await _smsSender.SendOTP(user.PhoneNumber!,_siteSettings.SmsSettings.LoginCodeTemplateName,code);
            }

            return new(phoneNumberOrEmail,_siteSettings.WaitForSendCodeSeconds,user.SendCodeLastTime);
        }

        if(isEmail)
        {
            user = new()
            {
                UserName = phoneNumberOrEmail.Split('@')[0],
                Email = phoneNumberOrEmail,
                SendCodeLastTime = sendCodeLastTime
            };
            var result = await _userManager.CreateAsync(user);
            if(!result.Succeeded)
            {
                throw new BadRequestException(result.GetErrors());
            }

            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.Email);
            var body = EmailTemplates.LoginCodeEmail(code,user.Email!);
            await _emailSender.SendEmailAsync(user.Email!,Messages.Subjects.LoginCodeMailSubject,body);
        }
        else
        {
            user = new()
            {
                UserName = phoneNumberOrEmail,
                PhoneNumber = phoneNumberOrEmail,
                Email = $"{StringHelper.GenerateGuid()}@test.com",
                SendCodeLastTime = sendCodeLastTime
            };
            var result = await _userManager.CreateAsync(user);
            if(!result.Succeeded)
            {
                throw new BadRequestException(result.GetErrors());
            }
            var code = await _userManager.GenerateChangePhoneNumberTokenAsync(user,user.PhoneNumber);
            await _smsSender.SendOTP(user.PhoneNumber!,_siteSettings.SmsSettings.LoginCodeTemplateName,code);
        }

        return new(phoneNumberOrEmail,_siteSettings.WaitForSendCodeSeconds,user.SendCodeLastTime);
    }
}