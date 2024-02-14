namespace Restaurant.Domain.Entities.Identity;

public class Role : IdentityRole<long>, IAuditableEntity
{
    #region Relations

    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }

    #endregion Relations
}