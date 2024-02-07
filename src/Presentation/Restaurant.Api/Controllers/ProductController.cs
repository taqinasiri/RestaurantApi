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