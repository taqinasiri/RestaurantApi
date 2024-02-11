using Restaurant.Application.Features.Category.Requests.Commands;
using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
[Authorize(PolicyNames.CategoryManager,AuthenticationSchemes = "Bearer")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    ///  Get All Categories by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">Items per page</param>
    /// <param name="orderDescending"></param>
    /// <param name="orderBy">0 : Default | 1 : Title | 2 : Slug</param>
    /// <param name="title">filter by title</param>
    /// <param name="slug">filter by slug</param>
    /// <param name="parentId">filter by parentId</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseOkApiResult<GetCategoriesByFilterResponse>]
    public async Task<ActionResult> Get(int page = 1,int take = 10,bool orderDescending = true,CategoryOrdering? orderBy = null,string? title = null,string? slug = null,int parentId = 0)
    {
        GetCategoriesByFilterQuery request = new()
        {
            Filters = new(title,slug,parentId),
            Ordering = new(orderBy ?? CategoryOrdering.Default,orderDescending),
            Paging = new(page,take)
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Get categories tree structure
    /// </summary>
    [AllowAnonymous]
    [HttpGet("Tree/{depth:int}")]
    [ProducesResponseOkApiResult<GetCategoriesTreeResponse>]
    public async Task<ActionResult> Get(byte depth = 2)
    {
        var response = await _mediator.Send(new GetCategoriesTreeQuery() { Depth = depth });
        return Ok(response);
    }

    /// <summary>
    /// Get a Category Details
    /// </summary>
    /// <remarks>
    /// - 404 : Category not found
    /// </remarks>
    [AllowAnonymous]
    [HttpGet("{id:int}")]
    [ProducesResponseOkApiResult<GetCategoryDetailsResponse>]
    public async Task<ActionResult> Get(int id)
    {
        var response = await _mediator.Send(new GetCategoryDetailsQuery(id));
        return Ok(response);
    }

    #endregion GET

    #region POST

    /// <summary>
    /// Create a new category
    /// </summary>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// - 404 : Category not found
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult> Create(CreateCategoryCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST

    #region PUT

    /// <summary>
    /// Update a category
    /// </summary>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// - 404 : Category not found | Parent not found
    /// </remarks>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(UpdateCategoryCommand command,int id)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    #endregion PUT

    #region DELETE

    /// <summary>
    /// Delete a Category
    /// </summary>
    /// <remarks>
    /// - 404 : Category not found
    /// </remarks>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCategoryCommand();
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    #endregion DELETE
}