using Restaurant.Application.Features.Table.Requests.Commands;
using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class TableController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get a table details
    /// </summary>
    /// <remarks>
    /// 404 : table not found
    /// </remarks>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var response = await _mediator.Send(new GetTableDetailsQuery(id));
        return Ok(response);
    }

    #endregion GET

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

    #region PUT

    /// <summary>
    /// Update a table
    /// </summary>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// - 404 : table not found
    /// </remarks>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(UpdateTableCommand command,long id)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    #endregion PUT

    #region DELETE

    /// <summary>
    /// Delete a table
    /// </summary>
    /// <remarks>
    /// 404 : Table not found
    /// </remarks>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteTableCommand(id));
        return Ok();
    }

    #endregion DELETE
}