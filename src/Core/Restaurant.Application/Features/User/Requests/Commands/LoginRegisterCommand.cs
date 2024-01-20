namespace Restaurant.Application.Features.User.Requests.Commands;

public class LoginRegisterCommand : IRequest<LoginRegisterResponse>
{
    public string PhoneNumberOrEmail { get; set; }
}

public record LoginRegisterResponse(string PhoneNumberOrEmail,int ResendSeconds,DateTime SendCodeLastTime);