namespace Restaurant.Domain.Entities.Identity;

public class UserRole : IdentityUserRole<long>
{
    #region Relations

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }

    #endregion Relations
}