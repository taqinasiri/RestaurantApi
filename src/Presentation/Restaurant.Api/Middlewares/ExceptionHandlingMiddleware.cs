using Restaurant.Api.Models;

namespace Restaurant.Api.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Application.Exceptions.BadRequestException exception)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            var result = new ApiResult(false,System.Net.HttpStatusCode.BadRequest,exception.Message)
            {
                Errors = exception.Errors
            };

            await context.Response.WriteAsJsonAsync(result);
        }
        catch(Application.Exceptions.ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            var result = new ApiResult(false,System.Net.HttpStatusCode.BadRequest,"Validation Error")
            {
                ValidationErrors = exception.Errors ?? []
            };

            await context.Response.WriteAsJsonAsync(result);
        }
        catch(Application.Exceptions.NotFoundException exception)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            var result = new ApiResult(false,System.Net.HttpStatusCode.NotFound,exception.Message);
            await context.Response.WriteAsJsonAsync(result);
        }
        //catch
        //{
        //    context.Response.StatusCode = StatusCodes.Status200OK;
        //    var result = new ApiResult(false,System.Net.HttpStatusCode.InternalServerError);
        //    await context.Response.WriteAsJsonAsync(result);
        //}
    }
}