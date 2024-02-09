using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class ProductBranchController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region POST

    /// <summary>
    /// Add a product to a branch
    /// </summary>
    /// <remarks>
    /// 404 : Product not found | Branch not found
    /// > **if Product to exits returned 200 whit out error or edit**
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> AddProductToBranch(AddProductToBranchCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}