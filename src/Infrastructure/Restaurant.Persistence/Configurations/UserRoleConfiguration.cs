namespace Restaurant.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(userRole => userRole.User).
            WithMany(user => user.UserRoles)
            .HasForeignKey(userRole => userRole.UserId);

        builder.HasOne(userRole => userRole.Role).
            WithMany(role => role.UserRoles)
            .HasForeignKey(userRole => userRole.RoleId);

        builder.HasKey(key => new { key.UserId,key.RoleId });

        builder.ToTable("UserRoles");
    }
}