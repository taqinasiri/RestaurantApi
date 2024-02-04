using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.Configurations;

public class CategoryToProductConfiguration : IEntityTypeConfiguration<CategoryToProduct>
{
    public void Configure(EntityTypeBuilder<CategoryToProduct> builder)
    {
        builder.HasOne(ctp => ctp.Product)
            .WithMany(p => p.Categories)
            .HasForeignKey(ctp => ctp.ProductId);

        builder.HasOne(ctp => ctp.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(ctp => ctp.CategoryId);

        builder.HasKey(ctp => new { ctp.ProductId,ctp.CategoryId });
    }
}