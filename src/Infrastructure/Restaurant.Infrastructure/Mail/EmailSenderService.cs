using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Restaurant.Application.Models;

namespace Restaurant.Infrastructure.Mail;

public class EmailSenderService(IOptionsSnapshot<SiteSettings> emailConfig) : IEmailSenderService
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

        using var client = new SmtpClient();
        await client.ConnectAsync(_emailConfig.Host,_emailConfig.Port,_emailConfig.UseSSL).ConfigureAwait(false);
        await client.AuthenticateAsync(_emailConfig.UserName,_emailConfig.Password).ConfigureAwait(false);
        await client.SendAsync(mimeMessage).ConfigureAwait(false);
        await client.DisconnectAsync(true).ConfigureAwait(false);
    }
}