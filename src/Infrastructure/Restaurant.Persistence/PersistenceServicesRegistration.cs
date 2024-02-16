using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Contracts.Persistence;
using Restaurant.Application.Models;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Interceptors;
using Restaurant.Persistence.Repositories;
using Restaurant.Persistence.Services;
using Restaurant.Persistence.Services.Identity;
using System.Security.Principal;

namespace Restaurant.Persistence;

public static class PersistenceServicesRegistration
{
    private const string EmailConfirmationTokenProviderName = "ConfirmEmail";

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        var siteSettings = configuration.Get<SiteSettings>(configuration.Bind);

        services.AddDataBase(siteSettings.ConnectionStrings.ApplicationDbContextConnection);
        services.AddScoped<IDbInitializer,DbInitializer>();

        services.AddRepositories();

        services.AddIdentityServices();
        services.AddIdentityOptions(siteSettings);

        services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        services.AddSingleton<IPrincipal>(provider => provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current!);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IProductRepository,ProductRepository>();
        services.AddScoped<IBranchRepository,BranchRepository>();
        services.AddScoped<IBranchWorkingHoursRepository,BranchWorkingHoursRepository>();
        services.AddScoped<IImageRepository,ImageRepository>();
        services.AddScoped<IProductBranchRepository,ProductBranchRepository>();
        services.AddScoped<ITableRepository,TableRepository>();
        return services;
    }

    public static void InitializeDb(this IServiceProvider serviceProvider,IConfiguration configuration)
    {
        var siteSettings = configuration.Get<SiteSettings>(configuration.Bind);
        using(var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            serviceProvider.RunScopedService<IDbInitializer>(DbInitialize =>
            {
                DbInitialize.Initialize();
                DbInitialize.SeedData(siteSettings!);
            });
        }
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

    private static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationUserManager,ApplicationUserManager>();
        services.AddScoped<UserManager<User>,ApplicationUserManager>();

        services.AddScoped<IApplicationRoleManager,ApplicationRoleManager>();
        services.AddScoped<RoleManager<Role>,ApplicationRoleManager>();

        services.AddScoped<IApplicationSignInManager,ApplicationSignInManager>();
        services.AddScoped<SignInManager<User>,ApplicationSignInManager>();

        services.AddScoped<IJwtService,JwtService>();

        return services;
    }

    private static IServiceCollection AddIdentityOptions(this IServiceCollection services,SiteSettings siteSettings)
    {
        services.AddConfirmEmailDataProtectorTokenOptions(siteSettings);
        services.AddIdentity<User,Role>(identityOptions =>
        {
            SetPasswordOptions(identityOptions.Password,siteSettings);
            SetSignInOptions(identityOptions.SignIn,siteSettings);
            SetUserOptions(identityOptions.User);
            SetLockoutOptions(identityOptions.Lockout,siteSettings);
        }).AddUserManager<ApplicationUserManager>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<ConfirmEmailDataProtectorTokenProvider<User>>(EmailConfirmationTokenProviderName);

        services.ConfigureApplicationCookie(identityOptionsCookies =>
        {
            var provider = services.BuildServiceProvider();
            SetApplicationCookieOptions(provider,identityOptionsCookies,siteSettings);
        });

        services.EnableImmediateLogout();

        return services;
    }

    #region Identity Options

    private static void AddConfirmEmailDataProtectorTokenOptions(this IServiceCollection services,SiteSettings siteSettings)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Tokens.EmailConfirmationTokenProvider = EmailConfirmationTokenProviderName;
        });

        services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = siteSettings.EmailConfirmationTokenProviderLifespan;
        });
    }

    private static void EnableImmediateLogout(this IServiceCollection services)
    {
        services.Configure<SecurityStampValidatorOptions>(options =>
        {
            // enables immediate logout, after updating the user's stat.
            options.ValidationInterval = TimeSpan.Zero;
            options.OnRefreshingPrincipal = principalContext => { return Task.CompletedTask; };
        });
    }

    private static void SetApplicationCookieOptions(IServiceProvider provider,CookieAuthenticationOptions identityOptionsCookies,SiteSettings siteSettings)
    {
        identityOptionsCookies.Cookie.Name = siteSettings.CookieOptions.CookieName;
        identityOptionsCookies.Cookie.HttpOnly = true;
        identityOptionsCookies.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        identityOptionsCookies.Cookie.SameSite = SameSiteMode.Lax;
        // this cookie will always be stored regardless of the user's consent
        identityOptionsCookies.Cookie.IsEssential = true;

        identityOptionsCookies.ExpireTimeSpan = siteSettings.CookieOptions.ExpireTimeSpan;
        identityOptionsCookies.SlidingExpiration = siteSettings.CookieOptions.SlidingExpiration;
        identityOptionsCookies.LoginPath = siteSettings.CookieOptions.LoginPath;
        identityOptionsCookies.LogoutPath = siteSettings.CookieOptions.LogoutPath;
        identityOptionsCookies.AccessDeniedPath = siteSettings.CookieOptions.AccessDeniedPath;
    }

    private static void SetLockoutOptions(LockoutOptions identityOptionsLockout,SiteSettings siteSettings)
    {
        identityOptionsLockout.AllowedForNewUsers = siteSettings.LockoutOptions.AllowedForNewUsers;
        identityOptionsLockout.DefaultLockoutTimeSpan = siteSettings.LockoutOptions.DefaultLockoutTimeSpan;
        identityOptionsLockout.MaxFailedAccessAttempts = siteSettings.LockoutOptions.MaxFailedAccessAttempts;
    }

    private static void SetPasswordOptions(PasswordOptions identityOptionsPassword,SiteSettings siteSettings)
    {
        identityOptionsPassword.RequireDigit = siteSettings.PasswordOptions.RequireDigit;
        identityOptionsPassword.RequireLowercase = siteSettings.PasswordOptions.RequireLowercase;
        identityOptionsPassword.RequireNonAlphanumeric = siteSettings.PasswordOptions.RequireNonAlphanumeric;
        identityOptionsPassword.RequireUppercase = siteSettings.PasswordOptions.RequireUppercase;
        identityOptionsPassword.RequiredLength = siteSettings.PasswordOptions.RequiredLength;
    }

    private static void SetSignInOptions(SignInOptions identityOptionsSignIn,SiteSettings siteSettings) => identityOptionsSignIn.RequireConfirmedEmail = siteSettings.EnableEmailConfirmation;

    private static void SetUserOptions(UserOptions identityOptionsUser) => identityOptionsUser.RequireUniqueEmail = true;

    #endregion Identity Options
}