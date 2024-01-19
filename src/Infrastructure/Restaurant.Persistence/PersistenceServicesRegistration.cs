using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Models;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Interceptors;
using System.Security.Claims;
using System.Security.Principal;

namespace Restaurant.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        var siteSettings = configuration.Get<SiteSettings>(configuration.Bind);
        if(siteSettings is null)
            throw new ArgumentNullException(nameof(siteSettings)); //TODO

        services.AddDataBase(siteSettings.ConnectionStrings.ApplicationDbContextConnection);

        services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        services.AddSingleton<IPrincipal>(provider => provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current!);
        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services,string connectionString)
    {
        services.AddSingleton<AuditableEntityInterceptor>();
        services.AddSingleton<PersianCleanerCommandInterceptor>();
        services.AddDbContextPool<ApplicationDbContext>((sp,options) =>
        {
            options.UseSqlServer(connectionString);
            options.AddInterceptors(
                sp.GetRequiredService<AuditableEntityInterceptor>(),
                sp.GetRequiredService<PersianCleanerCommandInterceptor>());
        });
        return services;
    }
}