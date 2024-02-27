using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Application.Models;
using Restaurant.Infrastructure.File;
using Restaurant.Infrastructure.Mail;
using Restaurant.Infrastructure.Payment;

namespace Restaurant.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment)
    {
        var siteSettings = configuration.Get<SiteSettings>(configuration.Bind);
        if(environment.IsDevelopment())
        {
            services.AddScoped<IEmailSenderService,LocalEmailWriterService>();
            services.AddScoped<IPaymentService,ZarinPalSandboxPaymentService>();
        }
        else
        {
            services.AddScoped<IEmailSenderService,EmailSenderService>();
            services.AddScoped<IPaymentService,ZarinPalPaymentService>();
        }
        services.AddScoped<IFileUploadService,FileUploadService>();

        return services;
    }
}