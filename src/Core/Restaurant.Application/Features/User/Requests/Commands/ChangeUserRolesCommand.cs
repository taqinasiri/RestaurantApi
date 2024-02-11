namespace Restaurant.Application.Features.User.Requests.Commands;

public class ChangeUserRolesCommand : IRequest
{
    public long UserId { get; set; }
    public string[] NewRoles { get; set; } = null!;
    public string[] RemoveRoles { get; set; } = null!;
}