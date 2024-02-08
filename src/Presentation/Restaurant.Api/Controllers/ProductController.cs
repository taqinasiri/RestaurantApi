using Restaurant.Application.Extensions;
using Restaurant.Application.Features.Product.Requests.Commands;
using Restaurant.Application.Features.Product.Requests.Queries;
using Uri = System.Web.Http;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class ProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    [HttpGet]
    [ProducesResponseOkApiResult<GetProductsByFilterResponse>]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,ProductOrdering? orderBy = null,
        string? title = null,string? slug = null,
        string? categories = null,
        string? branches = null)
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
            Filters = new(title,slug)
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
    /// - 404 : Parent not found
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult> Create(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}