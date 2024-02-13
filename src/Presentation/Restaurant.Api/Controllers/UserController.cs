using Restaurant.Application.Features.User.Requests.Commands;
using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
[Authorize(PolicyNames.Admin,AuthenticationSchemes = "Bearer")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var result = await _mediator.Send(new GetUserDetailsQuery(id));
        return Ok(result);
    }

    #endregion GET

    #region POST

    [HttpPost]
    public async Task<IActionResult> ChangeRoles(ChangeUserRolesCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}