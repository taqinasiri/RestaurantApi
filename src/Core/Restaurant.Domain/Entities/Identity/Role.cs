namespace Restaurant.Domain.Entities.Identity;

public class Role : IdentityRole<long>, IAuditableEntity
{
    #region Relations

    public ICollection<UserBranchRoles>? BranchRoles { get; set; }

    #endregion Relations
}