using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Entities;

public class UserBranchRoles : IAuditableEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public long BranchId { get; set; }

    #region Relations

    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
    public Branch Branch { get; set; } = null!;

    #endregion Relations
}