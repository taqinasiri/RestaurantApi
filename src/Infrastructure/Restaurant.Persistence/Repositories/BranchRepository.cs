namespace Restaurant.Persistence.Repositories;

public class BranchRepository(ApplicationDbContext context) : GenericRepository<Branch>(context), IBranchRepository
{
    private DbSet<Branch> _branches = context.Set<Branch>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _branches.AnyAsync(p => p.Title == title || p.Slug == slug);
}