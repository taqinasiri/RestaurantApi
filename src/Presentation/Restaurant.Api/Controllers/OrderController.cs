using DNTCommon.Web.Core;
using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Application.Features.Order.Requests.Queries;
using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
[Authorize(AuthenticationSchemes = "Bearer")]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get User Orders by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">items per page</param>
    /// <param name="orderDescending">Default value : true</param>
    /// <param name="orderBy">0 : Default | 1 : TotalPrice | 2 : PayDateTime </param>
    [HttpGet]
    [ProducesResponseOkApiResult<GetUserOrdersByFilterResponse>]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,OrderOrdering? orderBy = null,
        int? fromPrice = null,int? toPrice = null,
        DateTime? fromDateTime = null,DateTime? toDateTime = null
        )
    {
        var command = new GetUserOrdersByFilterQuery()
        {
            UserId = User.Identity!.GetUserId()!.ToLong(),
            Filters = new(fromPrice,toPrice,fromDateTime,toDateTime),
            Ordering = new(orderBy ?? OrderOrdering.Default,orderDescending),
            Paging = new(page,take)
        };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    #endregion GET

    #region POST

    /// <summary>
    /// Create a new order for user
    /// </summary>
    /// <remarks>
    /// - 400 : User has during order | Branch closed in time | Time not free | FromTime and ToTome not valid
    /// - 404 : Products in branch not found
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        command.UserId = User.Identity!.GetUserId()!.ToLong();
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Cancel a `Paying` order
    /// </summary>
    /// <remarks>
    /// - 404 : Order not found
    /// - 403 : Order is not for this user
    /// - 400 : Order status != Paying
    /// </remarks>
    [HttpPost("[action]/{orderId:long}")]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Cancel(int orderId)
    {
        var command = new CancelOrderCommand
        {
            UserId = User.Identity!.GetUserId()!.ToLong(),
            OrderId = orderId
        };
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST

    #region DELETE

    /// <summary>
    /// Delete a `During` Order
    /// </summary>
    /// <remarks>
    /// - 404 : Order not found
    /// - 403 : Order is not for this user
    /// - 400 : Order status != During
    ///  </remarks>
    [HttpDelete("{orderId:long}")]
    public async Task<IActionResult> Delete(long orderId)
    {
        await _mediator.Send(new DeleteOrderCommand()
        {
            OrderId = orderId,
            UserId = User.Identity!.GetUserId()!.ToLong(),
        });
        return Ok();
    }

    #endregion DELETE
}