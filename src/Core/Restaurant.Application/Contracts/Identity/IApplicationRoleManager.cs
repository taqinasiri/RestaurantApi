namespace Restaurant.Application.Contracts.Identity;

public interface IApplicationRoleManager : IDisposable
{
    #region BaseClass

    Task<IdentityResult> CreateAsync(Role role);

    Task<IdentityResult> UpdateAsync(Role role);

    Task<IdentityResult> DeleteAsync(Role role);

    Task<string> GetRoleIdAsync(Role role);

    Task<string> GetRoleNameAsync(Role role);

    Task<IdentityResult> SetRoleNameAsync(Role role,string roleName);

    Task<Role> FindByIdAsync(string id);

    Task<Role> FindByNameAsync(string normalizedName);

    Task<IList<Claim>> GetClaimsAsync(Role role);

    Task<IdentityResult> AddClaimAsync(Role role,Claim claim);

    Task<IdentityResult> RemoveClaimAsync(Role role,Claim claim);

    IdentityErrorDescriber ErrorDescriber { get; set; }
    IQueryable<Role> Roles { get; }

    #endregion BaseClass
}