using Microsoft.Extensions.Options;
using Restaurant.Application.Models;

namespace Restaurant.Infrastructure.Sms;

public class LocalSmsWriterService(IOptionsMonitor<SiteSettings> options) : ISmsSenderService
{
    private readonly SmsSettings _smsConfig = options.CurrentValue.SmsSettings;

    public async ValueTask<bool> SendOTP(string receptor,string templateName,string token1,string? token2 = "",string? token3 = "")
    {
        string body = $"""
            Receptor : {receptor}
            Template : {templateName}
            Token1   : {token1}
            Token2   : {token2}
            Token3   : {token3}
            """;

        string smsPath = Path.Combine(Directory.GetCurrentDirectory(),_smsConfig.LocalWritePath);
        if(!Path.Exists(smsPath))
            Directory.CreateDirectory(smsPath);
        System.IO.File.WriteAllText(smsPath + $"/{Guid.NewGuid():N}-OTP.txt",body);

        return true;
    }

    public async ValueTask<bool> SendPublic(string receptor,string message)
    {
        string body = $"""
            Receptor : {receptor}
            Message  : {message}
            """;

        string smsPath = Path.Combine(Directory.GetCurrentDirectory(),_smsConfig.LocalWritePath,$"{Guid.NewGuid():N}-Public.txt");
        if(!Path.Exists(smsPath))
            Directory.CreateDirectory(smsPath);
        System.IO.File.WriteAllText(smsPath + $"/{Guid.NewGuid():N}-OTP.txt",body);
        return true;
    }
}