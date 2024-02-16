namespace Restaurant.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(c => c.Image)
            .WithOne(i => i.Category)
            .HasForeignKey<Category>(c => c.ImageId);
    }
}