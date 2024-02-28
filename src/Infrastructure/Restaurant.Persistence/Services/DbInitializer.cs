using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Models;
using Restaurant.Domain.Constants;

namespace Restaurant.Persistence.Services;

public class DbInitializer(
        IApplicationUserManager userManager,
        IServiceScopeFactory scopeFactory,
        IApplicationRoleManager roleManager,
        ILogger<IDbInitializer> logger,ApplicationDbContext dbContext) : IDbInitializer
{
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly ILogger<IDbInitializer> _logger = logger;
    private readonly IApplicationRoleManager _roleManager = roleManager;
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly ApplicationDbContext _dbContext = dbContext;

    public void Initialize() => _scopeFactory.RunScopedService<ApplicationDbContext>(context => context.Database.Migrate());

    public void SeedData(SiteSettings siteSettings) => _scopeFactory.RunScopedService<IDbInitializer>(dbInitializer =>
    {
        var result = dbInitializer.SeedRole(ConstantRoles.Admin).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedRole(ConstantRoles.BranchManager).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedRole(ConstantRoles.ProductManager).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedRole(ConstantRoles.TableManager).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedRole(ConstantRoles.CategoryManager).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedRole(ConstantRoles.OrderManage).Result;
        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();

        result = dbInitializer.SeedAdmin(siteSettings.AdminUserSeed.UserName,
            siteSettings.AdminUserSeed.Password,
            siteSettings.AdminUserSeed.Email,
            siteSettings.UserDefaultAvatar).Result;

        if(result == IdentityResult.Failed())
            throw new InvalidOperationException();
    });

    public async Task<IdentityResult> SeedAdmin(string userName,string password,string email,string avatar)
    {
        var adminUser = await _userManager.FindByNameAsync(userName);
        if(adminUser is not null)
        {
            return IdentityResult.Success;
        }

        var adminRole = await _roleManager.FindByNameAsync(ConstantRoles.Admin);
        if(adminRole is null)
        {
            return IdentityResult.Failed();
        }

        adminUser = new()
        {
            UserName = userName,
            Email = email,
            EmailConfirmed = true,
            Avatar = new()
            {
                Name = avatar,
                UploadDate = DateTime.Now,
            }
        };

        var adminUserResult = await _userManager.CreateAsync(adminUser,password);
        if(adminUserResult == IdentityResult.Failed())
        {
            return IdentityResult.Failed();
        }

        var addToRoleResult = await _userManager.AddToRoleAsync(adminUser,adminRole.Name!);
        if(addToRoleResult == IdentityResult.Failed())
        {
            return IdentityResult.Failed();
        }

        return IdentityResult.Success;
    }

    public async Task<IdentityResult> SeedRole(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if(role is not null)
        {
            return IdentityResult.Success;
        }

        role = new() { Name = roleName };
        return await _roleManager.CreateAsync(role);
    }
}