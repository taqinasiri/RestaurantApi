namespace Restaurant.Domain.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
    public long? AvatarId { get; set; }
    public DateTime SendCodeLastTime { get; set; }
    public bool IsActive { get; set; } = true;

    #region Relations

    public virtual ICollection<UserClaim>? UserClaims { get; set; }
    public virtual ICollection<UserLogin>? UserLogins { get; set; }
    public virtual ICollection<UserToken>? UserTokens { get; set; }
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    public ICollection<Branch>? Branches { get; set; }
    public Image? Avatar { get; set; }

    #endregion Relations
}