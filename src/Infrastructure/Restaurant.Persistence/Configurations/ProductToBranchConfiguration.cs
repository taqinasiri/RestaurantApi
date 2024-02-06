namespace Restaurant.Persistence.Configurations;

public class ProductToBranchConfiguration : IEntityTypeConfiguration<ProductToBranch>
{
    public void Configure(EntityTypeBuilder<ProductToBranch> builder)
    {
        builder.HasOne(itp => itp.Product)
            .WithMany(p => p.Branches)
            .HasForeignKey(itp => itp.ProductId);

        builder.HasOne(itp => itp.Branch)
            .WithMany(p => p.Products)
            .HasForeignKey(itp => itp.BranchId);

        builder.HasKey(itp => new { itp.ProductId,itp.BranchId });
    }
}