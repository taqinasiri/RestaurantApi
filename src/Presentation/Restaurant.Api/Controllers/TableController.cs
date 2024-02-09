using Restaurant.Application.Features.Table.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class TableController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region POST

    /// <summary>
    /// Create a table
    /// </summary>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// - 404 : branch not found
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Create(CreateTableCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}