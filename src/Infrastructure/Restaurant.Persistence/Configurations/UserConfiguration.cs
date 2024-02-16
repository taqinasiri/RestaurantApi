namespace Restaurant.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasOne(c => c.Avatar)
            .WithOne(i => i.User)
            .HasForeignKey<User>(c => c.AvatarId);
    }
}