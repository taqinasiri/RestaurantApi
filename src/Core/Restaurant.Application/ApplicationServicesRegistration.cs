using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Configs.MediatR;
using Restaurant.Application.Models;
using System.Reflection;

namespace Restaurant.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<SiteSettings>(configuration.Bind);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}