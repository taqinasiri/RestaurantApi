using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Api.Models;
using System.Net;

namespace Restaurant.Api.Attributes;

public class ApiResultFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        switch(context.Result)
        {
            case OkObjectResult okObjectResult:
                context.Result = new JsonResult(new ApiResult<object>(true,HttpStatusCode.OK,okObjectResult.Value)) { StatusCode = StatusCodes.Status200OK };
                break;

            case OkResult:
                context.Result = new JsonResult(new ApiResult(true,HttpStatusCode.OK)) { StatusCode = StatusCodes.Status200OK };
                break;

            case ContentResult contentResult:
                context.Result = new JsonResult(new ApiResult(true,HttpStatusCode.OK,contentResult.Content!)) { StatusCode = StatusCodes.Status200OK };
                break;

            case ObjectResult objectResult when objectResult.Value is not ApiResult:
                context.Result = new JsonResult(new ApiResult<object>(true,HttpStatusCode.OK,objectResult.Value)) { StatusCode = StatusCodes.Status200OK };
                break;
        }
        base.OnResultExecuting(context);
    }
}