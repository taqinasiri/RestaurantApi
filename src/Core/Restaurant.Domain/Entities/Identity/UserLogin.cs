namespace Restaurant.Domain.Entities.Identity;

public class UserLogin : IdentityUserLogin<long>
{
    public virtual User User { get; set; }
}