using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Restaurant.Application.Models;

namespace Restaurant.Infrastructure.Mail;

public class LocalEmailWriterService(IOptionsSnapshot<SiteSettings> emailConfig) : IEmailSenderService
{
    private readonly EmailConfigs _emailConfig = emailConfig.Value.EmailConfigs;

    public async Task SendEmailAsync(string to,string subject,string body)
    {
        var mimeMessage = new MimeMessage
        {
            Subject = subject,
            Date = DateTime.Now,
            Sender = new MailboxAddress(_emailConfig.SiteTitle,_emailConfig.UserName),
            Body = new TextPart(TextFormat.Html)
            {
                Text = body
            }
        };
        mimeMessage.From.Add(new MailboxAddress(_emailConfig.SiteTitle,_emailConfig.UserName));
        mimeMessage.To.Add(new MailboxAddress("",to));

        string emailPath = Path.Combine(Directory.GetCurrentDirectory(),_emailConfig.LocalWritePath);
        if(!Path.Exists(emailPath))
            Directory.CreateDirectory(emailPath);
        await using var stream = new FileStream(emailPath + $"/{Guid.NewGuid():N}.eml",FileMode.CreateNew);
        await mimeMessage.WriteToAsync(stream);
    }
}