namespace Restaurant.Persistence.Repositories;

public class ImageRepository(ApplicationDbContext context) : GenericRepository<Image>(context), IImageRepository
{
    private DbSet<Image> _images = context.Set<Image>();

    public async ValueTask<Image> FindByNameAsync(string name)
        => (await _images.SingleOrDefaultAsync(i => i.Name == name))!;

    public async ValueTask<Image> FindForBranch(string name,long branchId)
        => (await _images.SingleOrDefaultAsync(i => i.Name == name && i.Branches.First().Branch.Id == branchId))!;
}