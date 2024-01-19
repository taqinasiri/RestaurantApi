using Restaurant.Application.Models;

namespace Restaurant.Application.Contracts.Persistence;

public interface IDbInitializer
{
    void Initialize();

    void SeedData(SiteSettings siteSettings);

    Task<IdentityResult> SeedRole(string roleName);

    Task<IdentityResult> SeedAdmin(string userName,string password,string email,string avatar);
}