using DNTCommon.Web.Core;
using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
[Authorize(AuthenticationSchemes = "Bearer",Policy = PolicyNames.OrderManage)]
public class ManageOrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get Orders by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">items per page</param>
    /// <param name="orderDescending">Default value : true</param>
    /// <param name="orderBy">0 : Default | 1 : TotalPrice | 2 : PayDateTime </param>
    [HttpGet]
    [ProducesResponseOkApiResult<GetOrdersByFilterResponse>]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,OrderOrdering? orderBy = null,
        int? fromPrice = null,int? toPrice = null,
        DateTime? fromDateTime = null,DateTime? toDateTime = null,
        long? userId = null
        )
    {
        var command = new GetOrdersByFilterQuery()
        {
            IsMainAdmin = User.IsInRole(ConstantRoles.Admin),
            AdminId = User.Identity!.GetUserId()!.ToLong(),
            Filters = new(userId,fromPrice,toPrice,fromDateTime,toDateTime),
            Ordering = new(orderBy ?? OrderOrdering.Default,orderDescending),
            Paging = new(page,take)
        };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    #endregion GET
}