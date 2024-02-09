namespace Restaurant.Persistence.Repositories;

public class TableRepository(ApplicationDbContext context) : GenericRepository<Table>(context), ITableRepository
{
    private DbSet<Table> _tables = context.Set<Table>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _tables.AnyAsync(p => p.Title == title || p.Slug == slug);
}