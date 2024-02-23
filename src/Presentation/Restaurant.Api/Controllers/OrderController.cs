using DNTCommon.Web.Core;
using Restaurant.Application.Features.Order.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
[Authorize(AuthenticationSchemes = "Bearer")]
public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

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