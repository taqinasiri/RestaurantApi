using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurant.Application.Contracts.Identity;

namespace Restaurant.Persistence.Services.Identity;

public class ApplicationSignInManager(
    UserManager<User> userManager,
    IHttpContextAccessor contextAccessor,
    IUserClaimsPrincipalFactory<User> claimsFactory,
    IOptions<IdentityOptions> optionsAccessor,
    ILogger<SignInManager<User>> logger,
    IAuthenticationSchemeProvider schemes,
    IUserConfirmation<User> confirmation)
    : SignInManager<User>(userManager,contextAccessor,claimsFactory,optionsAccessor,logger,schemes,confirmation),
    IApplicationSignInManager
{
}