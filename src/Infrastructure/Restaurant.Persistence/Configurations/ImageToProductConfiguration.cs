using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.Configurations;

public class ImageToProductConfiguration : IEntityTypeConfiguration<ImageToProduct>
{
    public void Configure(EntityTypeBuilder<ImageToProduct> builder)
    {
        builder.HasOne(itp => itp.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(itp => itp.ImageId);

        builder.HasOne(itp => itp.Image)
            .WithMany(p => p.Products)
            .HasForeignKey(itp => itp.ImageId);

        builder.HasKey(itp => new { itp.ProductId,itp.ImageId });
    }
}