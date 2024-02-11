//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;

//namespace Restaurant.Application.Configs.Policies;

//public class BranchRoleRequirement : IAuthorizationRequirement
//{
//}

//public class BranchRoleHandler(IHttpContextAccessor httpContextAccessor) : AuthorizationHandler<BranchRoleRequirement>
//{
//    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

//    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,BranchRoleRequirement requirement)
//    {
//        HttpContext httpContent = _httpContextAccessor.HttpContext!;

//        if(!context.User.Identity.IsAuthenticated)
//            return;

//        int? userId = context.User.Identity?.GetId();
//    }
//}