using Restaurant.Application.Features.User.Requests.Commands;
using Restaurant.Application.Features.User.Requests.Queries;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiResultFilter]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    #region GET

    /// <summary>
    /// Get users by filter and ordering
    /// </summary>
    /// <param name="page">Page number</param>
    /// <param name="take">items per page</param>
    /// <param name="orderDescending">Default value : true</param>
    /// <param name="orderBy">0 : Default | 1 : UserName | 2 : Email | 3 : PhoneNumber </param>
    /// <param name="userName">filter by userName</param>
    /// <param name="email">filter by email</param>
    /// <param name="phoneNumber">filter by phone number</param>
    /// <param name="isActive">filter by active status</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get(
        int page = 1,int take = 10,
        bool orderDescending = true,UserOrdering? orderBy = null,
        string? userName = null,string? email = null,string? phoneNumber = null,bool? isActive = null)
    {
        GetUsersByFilterQuery request = new()
        {
            Filters = new(userName,email,phoneNumber,isActive),
            Ordering = new(orderBy ?? UserOrdering.Default,orderDescending),
            Paging = new(page,take)
        };

        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Get a user by id
    /// </summary>
    /// <remarks>
    /// - 404 : User not found
    /// </remarks>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)

    {
        var result = await _mediator.Send(new GetUserDetailsQuery(id));
        return Ok(result);
    }

    #endregion GET

    #region POST

    /// <summary>
    /// Change user roles
    /// </summary>
    /// <remarks>
    /// - 404 : User not found | Role not found
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> ChangeRoles(ChangeUserRolesCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion POST
}