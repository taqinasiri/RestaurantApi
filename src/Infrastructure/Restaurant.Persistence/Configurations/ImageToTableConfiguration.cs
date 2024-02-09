namespace Restaurant.Persistence.Configurations;

public class ImageToTableConfiguration : IEntityTypeConfiguration<ImageToTable>
{
    public void Configure(EntityTypeBuilder<ImageToTable> builder)
    {
        builder.HasOne(itp => itp.Table)
            .WithMany(p => p.Images)
            .HasForeignKey(itp => itp.TableId);

        builder.HasOne(itp => itp.Image)
            .WithMany(p => p.Tables)
            .HasForeignKey(itp => itp.ImageId);

        builder.HasKey(itp => new { itp.TableId,itp.ImageId });
    }
}