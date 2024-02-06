namespace Restaurant.Persistence.Configurations;

public class ImageToBranchConfiguration : IEntityTypeConfiguration<ImageToBranch>
{
    public void Configure(EntityTypeBuilder<ImageToBranch> builder)
    {
        builder.HasOne(itp => itp.Branch)
            .WithMany(p => p.Images)
            .HasForeignKey(itp => itp.BranchId);

        builder.HasOne(itp => itp.Image)
            .WithMany(p => p.Branches)
            .HasForeignKey(itp => itp.ImageId);

        builder.HasKey(itp => new { itp.BranchId,itp.ImageId });
    }
}