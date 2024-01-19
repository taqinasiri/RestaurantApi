using Microsoft.Extensions.Logging;
using Restaurant.Application.Contracts.Identity;

namespace Restaurant.Persistence.Services.Identity;

public class ApplicationRoleManager(
    IRoleStore<Role> store,
    IEnumerable<IRoleValidator<Role>> roleValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    ILogger<ApplicationRoleManager> logger)
    : RoleManager<Role>(store,roleValidators,keyNormalizer,errors,logger),
    IApplicationRoleManager
{
}