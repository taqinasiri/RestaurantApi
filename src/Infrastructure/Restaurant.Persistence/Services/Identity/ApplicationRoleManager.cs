using Microsoft.Extensions.Logging;
using Polly;
using Restaurant.Application.Contracts.Identity;

namespace Restaurant.Persistence.Services.Identity;

public class ApplicationRoleManager(
    IRoleStore<Role> store,
    IEnumerable<IRoleValidator<Role>> roleValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    ILogger<ApplicationRoleManager> logger,
    ApplicationDbContext context)
    : RoleManager<Role>(store,roleValidators,keyNormalizer,errors,logger),
    IApplicationRoleManager
{
    private readonly DbSet<Role> _roles = context.Set<Role>();
    private readonly ApplicationDbContext _context = context;

    public async Task<bool> IsExitsRoles(string[] newRoles)
        => await _roles.Select(r => r.Name).Intersect(newRoles).CountAsync() == newRoles.Length;
}