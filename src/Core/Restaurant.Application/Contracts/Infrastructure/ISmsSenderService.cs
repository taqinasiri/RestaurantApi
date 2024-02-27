namespace Restaurant.Application.Contracts.Infrastructure;

public interface ISmsSenderService
{
    ValueTask<bool> SendPublic(string receptor,string message);

    ValueTask<bool> SendOTP(string receptor,string templateName,string token1,string? token2 = "",string? token3 = "");
}