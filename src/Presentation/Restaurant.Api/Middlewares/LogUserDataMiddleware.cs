using DNTCommon.Web.Core;
using Serilog.Context;

namespace Restaurant.Api.Middlewares;

public class LogUserDataMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate next = next;

    public Task Invoke(HttpContext context)
    {
        LogContext.PushProperty("UserName",context.User.Identity.Name);
        LogContext.PushProperty("UserId",context.User.Identity.GetUserId());

        return next(context);
    }
}