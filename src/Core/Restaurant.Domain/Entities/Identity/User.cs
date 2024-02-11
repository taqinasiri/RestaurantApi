namespace Restaurant.Domain.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
    public string Avatar { get; set; } = null!;
    public DateTime SendCodeLastTime { get; set; }
    public bool IsActive { get; set; } = true;

    #region Relations

    public ICollection<Branch>? Branches { get; set; }

    #endregion Relations
}