namespace Restaurant.Persistence.Configurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasOne(userLogin => userLogin.User)
            .WithMany(user => user.UserLogins)
            .HasForeignKey(userLogin => userLogin.UserId);

        builder.ToTable("UserLogins");
    }
}