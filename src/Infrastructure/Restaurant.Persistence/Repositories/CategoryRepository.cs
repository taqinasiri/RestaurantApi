using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.Repositories;

public class CategoryRepository(ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    private DbSet<Category> _categories = context.Set<Category>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _categories.AnyAsync(c => c.Title == title || c.Slug == slug);
}