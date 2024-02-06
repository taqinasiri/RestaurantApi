using Restaurant.Application.Features.Branch.Requests.Commands;
using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class BranchController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get a branch by id
    /// </summary>
    /// <remarks>
    /// 404 : Branch not found
    /// </remarks>
    [HttpGet("{id:int}")]
    public async Task<ActionResult> Create(int id)
    {
        var result = await _mediator.Send(new GetBranchDetailsQuery(id));
        return Ok(result);
    }

    #endregion GET

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