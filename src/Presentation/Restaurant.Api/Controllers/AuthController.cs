using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Register/Login and send login code
    /// </summary>
    /// <remarks>
    /// 400 : Validation Error | Identity Error
    /// </remarks>
    [HttpPost]
    [ProducesResponseOkApiResult<LoginRegisterResponse>]
    public async Task<ActionResult> RegisterLogin(LoginRegisterCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}