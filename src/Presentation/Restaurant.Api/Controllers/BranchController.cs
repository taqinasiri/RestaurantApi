using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class BranchController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region POST

    /// <summary>
    /// Create a new branch
    /// </summary>
    /// <param name="command"></param>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult> Create(CreateBranchCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}