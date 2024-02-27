using Kavenegar;
using Microsoft.Extensions.Options;
using Restaurant.Application.Models;

namespace Restaurant.Infrastructure.Sms;

public class KavenegarSmsSenderService(IOptionsMonitor<SiteSettings> options) : ISmsSenderService
{
    private readonly SmsSettings _smsConfig = options.CurrentValue.SmsSettings;

    public async ValueTask<bool> SendOTP(string receptor,string templateName,string token1,string? token2 = "",string? token3 = "")
    {
        try
        {
            var api = new KavenegarApi(_smsConfig.ApiKey);
            await api.VerifyLookup(receptor,templateName,token1,token2,token3);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask<bool> SendPublic(string receptor,string message)
    {
        try
        {
            var api = new KavenegarApi(_smsConfig.ApiKey);
            await api.Send(_smsConfig.Sender,receptor,message);
            return true;
        }
        catch
        {
            return false;
        }
    }
}