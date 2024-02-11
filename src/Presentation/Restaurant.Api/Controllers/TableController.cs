using Restaurant.Application.Features.Table.Requests.Commands;
using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
[Authorize(PolicyNames.TableManage,AuthenticationSchemes = "Bearer")]
public class TableController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get tables by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">items per page</param>
    /// <param name="orderDescending">Default value : true</param>
    /// <param name="orderBy">0 : Default | 1 : Title | 2 : Slug</param>
    /// <param name="title">filter by title</param>
    /// <param name="slug">filter by slug</param>
    /// <param name="space">filter by space numbers</param>
    /// <param name="isAvailable">filter by available status</param>
    /// <param name="branchId">filter by branch id</param>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseOkApiResult<GetTablesByFilterResponse>]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,TableOrdering? orderBy = null,
        string? title = null,string? slug = null,byte? space = null,bool? isAvailable = null,int? branchId = null)
    {
        GetTablesByFilterQuery request = new()
        {
            Filters = new(title,slug,space,isAvailable,branchId),
            Ordering = new(orderBy ?? TableOrdering.Default,orderDescending),
            Paging = new(page,take)
        };

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Get a table details
    /// </summary>
    /// <remarks>
    /// 404 : table not found
    /// </remarks>
    [AllowAnonymous]
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