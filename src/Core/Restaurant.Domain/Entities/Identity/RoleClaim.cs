namespace Restaurant.Domain.Entities.Identity;

public class RoleClaim : IdentityRoleClaim<long>
{
    public virtual Role Role { get; set; }
}