using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Application.Models;
using Restaurant.Infrastructure.File;
using Restaurant.Infrastructure.Mail;

namespace Restaurant.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment)
    {
        services.Configure<SiteSettings>(configuration.Bind);
        if(environment.IsDevelopment())
        {
            services.AddScoped<IEmailSenderService,LocalEmailWriterService>();
        }
        else
        {
            services.AddScoped<IEmailSenderService,EmailSenderService>();
        }
        services.AddScoped<IFileUploadService,FileUploadService>();
        return services;
    }
}