using Restaurant.Application.Features.User.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region POST

    [HttpPost]
    public async Task<IActionResult> ChangeRoles(ChangeUserRolesCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}