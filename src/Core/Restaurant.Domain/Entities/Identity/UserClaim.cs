namespace Restaurant.Domain.Entities.Identity;

public class UserClaim : IdentityUserClaim<long>
{
    public virtual User User { get; set; }
}