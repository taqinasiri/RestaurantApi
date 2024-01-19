namespace Restaurant.Domain.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
    public string Avatar { get; set; } = null!;
}