using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class CategoryController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult> Create(CreateCategoryCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}