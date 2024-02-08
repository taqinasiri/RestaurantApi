using Restaurant.Application.Features.Branch.Requests.Commands;
using Restaurant.Application.Features.Branch.Requests.Queries;
using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class BranchController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    ///  Get All Branches by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">Items per page</param>
    /// <param name="orderDescending"></param>
    /// <param name="orderBy">0 : Default | 1 : Title | 2 : Slug</param>
    /// <param name="title">filter by title</param>
    /// <param name="slug">filter by slug</param>
    /// <param name="address">filter by address</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseOkApiResult<GetBranchesByFilterResponse>]
    public async Task<ActionResult> Get(int page = 1,int take = 10,bool orderDescending = true,BranchOrdering? orderBy = null,string? title = null,string? slug = null,string? address = null)
    {
        GetBranchesByFilterQuery request = new()
        {
            Filters = new(title,slug,address),
            Ordering = new(orderBy ?? BranchOrdering.Default,orderDescending),
            Paging = new(page,take)
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Get a branch by id
    /// </summary>
    /// <remarks>
    /// - 404 : Branch not found
    /// </remarks>
    [HttpGet("{id:int}")]
    [ProducesResponseOkApiResult<GetBranchDetailsResponse>]
    public async Task<ActionResult> Get(int id)
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

    #region PUT

    /// <summary>
    /// Update a branch
    /// </summary>
    /// <remarks>
    /// - 400 : File upload error
    /// - 404 : Branch not found
    /// </remarks>
    [HttpPut("{id:long}")]
    public async Task<ActionResult> Update(UpdateBranchCommand command,long id)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    #endregion PUT

    #region DELETE

    /// <summary>
    /// Delete a branch
    /// </summary>
    /// <remarks>
    /// - 404 : Branch not found
    /// </remarks>
    [HttpDelete("{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteBranchCommand(id));
        return Ok();
    }

    #endregion DELETE
}