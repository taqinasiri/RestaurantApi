namespace Restaurant.Persistence.Configurations;

public class UserBranchRolesConfiguration : IEntityTypeConfiguration<UserBranchRoles>
{
    public void Configure(EntityTypeBuilder<UserBranchRoles> builder)
    {
        builder.HasOne(ubr => ubr.User)
            .WithMany(p => p.BranchRoles)
            .HasForeignKey(ubr => ubr.UserId);

        builder.HasOne(ubr => ubr.Role)
            .WithMany(p => p.BranchRoles)
            .HasForeignKey(ubr => ubr.RoleId);

        builder.HasOne(ubr => ubr.Branch)
            .WithMany(p => p.BranchRoles)
            .HasForeignKey(ubr => ubr.BranchId);

        builder.HasKey(k => new { k.UserId,k.RoleId,k.BranchId });
    }
}