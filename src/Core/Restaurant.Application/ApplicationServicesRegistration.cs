using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurant.Application.Configs.MediatR;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Domain.Constants;
using System.Reflection;
using System.Text;

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

        var jwtConfigs = configuration.Get<SiteSettings>(configuration.Bind)!.JwtConfigs;
        services.AddJWTAuthentication(jwtConfigs);
        services.AddAuthorizationPolicies();
        return services;
    }

    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services,JwtConfigs jwtConfigs)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var secretKey = Encoding.UTF8.GetBytes(jwtConfigs.SecretKey);

            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                RequireSignedTokens = true,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ValidateAudience = true,
                ValidAudience = jwtConfigs.Audience,

                ValidateIssuer = true,
                ValidIssuer = jwtConfigs.Issuer,
            };
            options.Events = new JwtBearerEvents()
            {
                OnTokenValidated = async context =>
                {
                    var userManager = context.HttpContext.RequestServices.GetRequiredService<IApplicationUserManager>();
                    var signInManager = context.HttpContext.RequestServices.GetRequiredService<IApplicationSignInManager>();

                    var claimsIdentity = context.Principal?.Identity as ClaimsIdentity;
                    if(!claimsIdentity!.Claims.Any())
                        context.Fail("This token has no claims.");

                    var securityStamp = claimsIdentity.FindFirstValue(new ClaimsIdentityOptions().SecurityStampClaimType);
                    if(string.IsNullOrEmpty(securityStamp))
                        context.Fail("This token has no security stamp");

                    var userId = claimsIdentity.GetUserId();
                    var user = await userManager.FindByIdAsync(userId!);

                    if(!user.IsActive)
                        context.Fail("User is DeAtvice");

                    var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal!);
                    if(validatedUser is null)
                        context.Fail("Token security stamp is not valid.");
                }
            };
        });
        return services;
    }

    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(PolicyNames.Admin,policy => policy.RequireRole(ConstantRoles.Admin))
            .AddPolicy(PolicyNames.CategoryManager,policy => policy.RequireRole(ConstantRoles.Admin,ConstantRoles.CategoryManager))
            .AddPolicy(PolicyNames.ProductManager,policy => policy.RequireRole(ConstantRoles.Admin,ConstantRoles.ProductManager))
            .AddPolicy(PolicyNames.BranchManager,policy => policy.RequireRole(ConstantRoles.Admin,ConstantRoles.BranchManager))
            .AddPolicy(PolicyNames.TableManage,policy => policy.RequireRole(ConstantRoles.Admin,ConstantRoles.TableManager));
        return services;
    }
}