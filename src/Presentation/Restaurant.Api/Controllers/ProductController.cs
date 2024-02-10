using Restaurant.Application.Extensions;
using Restaurant.Application.Features.Product.Requests.Commands;
using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class ProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get products by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">items per page</param>
    /// <param name="orderDescending">Default value : true</param>
    /// <param name="orderBy">0 : Default | 1 : Title | 2 : Slug | 3 : Price</param>
    /// <param name="title">filter by title</param>
    /// <param name="slug">filter by slug</param>
    /// <param name="categories">filter by category ids | Template : 10,8,16</param>
    /// <param name="branches">filter by branch ids | Template : 3,2</param>
    [HttpGet]
    [ProducesResponseOkApiResult<GetProductsByFilterResponse>]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,ProductOrdering? orderBy = null,
        string? title = null,string? slug = null,
        string? categories = null,
        string? branches = null,
        int? fromPrice = null,int? toPrice = null,bool? isAvailable = null)
    {
        var categoryIds = new List<long>();
        var branchIds = new List<long>();
        try
        {
            categoryIds = categories.IsNotNull() ? categories.Split(',').Select(c => c.ToLong()).ToList() : null;
            branchIds = branches.IsNotNull() ? branches.Split(',').Select(c => c.ToLong()).ToList() : null;
        }
        catch
        {
            categoryIds = null;
            branchIds = null;
        }

        GetProductsByFilterQuery request = new()
        {
            Filters = new(title,slug,fromPrice,toPrice,isAvailable)
            {
                CategoryIds = categoryIds,
                AvailableInBranchIds = branchIds
            },

            Ordering = new(orderBy ?? ProductOrdering.Default,orderDescending),
            Paging = new(page,take)
        };

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Get a product details
    /// </summary>
    /// <remarks>
    /// 404 : product not found
    /// </remarks>
    [HttpGet("{id:int}")]
    [ProducesResponseOkApiResult<GetProductDetailsResponse>]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetProductDetailsQuery(id));
        return Ok(result);
    }

    #endregion GET

    #region POST

    /// <summary>
    /// Create a new product (Food)
    /// </summary>
    /// <param name="command"></param>
    /// <remarks>
    /// - 400 : Title or slug exists | File upload error
    /// - 404 : Category not found
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST

    #region PUT

    /// <summary>
    /// Update a product
    /// </summary>
    /// <remarks>
    /// 400 :  Title or slug exists | File upload error
    /// 404 : Product not found | Category not foun
    /// </remarks>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(UpdateProductCommand command,long id)
    {
        command.Id = id;
        await _mediator.Send(command);
        return Ok();
    }

    #endregion PUT

    #region DELETE

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <remarks>
    /// 404 : Product not found
    /// </remarks>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return Ok();
    }

    #endregion DELETE
}