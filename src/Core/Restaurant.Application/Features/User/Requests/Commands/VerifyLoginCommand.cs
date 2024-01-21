namespace Restaurant.Application.Features.User.Requests.Commands;

public class VerifyLoginCommand : IRequest<VerifyLoginResponse>
{
    public string Code { get; set; } = null!;
    public string PhoneNumberOrEmail { get; set; } = null!;
}

public record class VerifyLoginResponse(string Token);