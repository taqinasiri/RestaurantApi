namespace Restaurant.Application.Features.User.Requests.Commands;

public class UpdateUserCommand : IRequest
{
    public long Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public bool IsActive { get; set; }
    public string? AvatarBase64 { get; set; }
}