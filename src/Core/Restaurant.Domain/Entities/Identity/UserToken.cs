namespace Restaurant.Domain.Entities.Identity;

public class UserToken : IdentityUserToken<long>
{
    public virtual User User { get; set; }
}