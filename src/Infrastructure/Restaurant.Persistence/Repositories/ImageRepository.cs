namespace Restaurant.Persistence.Repositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(ApplicationDbContext context) : base(context)
    {
    }
}