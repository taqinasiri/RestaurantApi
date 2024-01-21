using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Restaurant.Api.Extensions;

public static class SwaggerRegistrationExtensions
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction =>
        {
            setupAction.SwaggerDoc("RestaurantManagement",new()
            {
                Title = "Restaurant Management Api",
                Version = "v1",
                Description = "Restaurant Management System",
                Contact = new()
                {
                    Email = "taqinasiri@outlook.com",
                    Name = "Mohammad Taqi Nasiri",
                },
                License = new()
                {
                    Name = "All Rights Reserved License"
                }
            });
            setupAction.AddSecurityDefinition("Bearer",new()
            {
                Name = "Authorization",
                Description = "Enter the Bearer Authorization string as following: `Bearer [Token]`",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            setupAction.AddSecurityRequirement(new()
            {
                {
                    new()
                    {
                        Reference = new()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },[]
                }
            });

            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory,"*.xml",SearchOption.TopDirectoryOnly).ToList();
            xmlFiles.ForEach(xmlFile => setupAction.IncludeXmlComments(xmlFile));
        });

        return services;
    }

    public static SwaggerUIOptions UseSwaggerUIOptions(this SwaggerUIOptions setupAction)
    {
        setupAction.SwaggerEndpoint("/swagger/RestaurantManagement/swagger.json","Restaurant Management Api");
        setupAction.InjectStylesheet("/css/swagger.css");
        return setupAction;
    }
}