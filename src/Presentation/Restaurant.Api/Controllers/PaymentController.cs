using DNTCommon.Web.Core;
using Restaurant.Application.Features.Order.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class PaymentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Verify user payment
    /// </summary>
    /// <remarks>
    /// Verify user payment with orderId, authority and status
    ///
    /// - 404 : Order not found
    /// - 400 : Verify Payment Filed
    /// </remarks>
    [HttpGet("{orderId:long}")]
    [ProducesResponseOkApiResult<VerifyOrderCommandResponse>]
    public async Task<IActionResult> Verify(long orderId,string authority,string status)
    {
        var response = await _mediator.Send(new VerifyOrderCommand()
        {
            OrderId = orderId,
            Authority = authority,
            Status = status
        });
        return Ok(response);
    }

    #endregion GET

    #region POST

    /// <summary>
    ///  Pay order with zarinPal
    /// </summary>
    /// <remarks>
    /// - Then `redirect the user to the received url` to perform the payment operation
    /// - Fill `CallbackUrl` with a url to which the user will be transferred after the payment operation, then you must confirm the payment operation with `Verify`
    ///
    /// - 404 : Order not found
    /// - 400 : Order is not for this user | Time not free
    /// </remarks>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    [ProducesResponseOkApiResult<PayOrderCommandResponse>]
    public async Task<IActionResult> Pay(PayOrderCommand command)
    {
        command.UserId = User.Identity!.GetUserId()!.ToLong();
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    #endregion POST
}