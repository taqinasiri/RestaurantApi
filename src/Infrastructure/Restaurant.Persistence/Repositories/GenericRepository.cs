namespace Restaurant.Persistence.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext _context = context;
    private DbSet<T> _entities = context.Set<T>();

    public async ValueTask<T?> FindByIdAsync(long id,bool isTracking = true)
        => isTracking ?
        await _entities.SingleOrDefaultAsync(e => e.Id == id) :
        await _entities.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);

    public async ValueTask<IReadOnlyList<T>> GetAllAsync(bool isGetDeleted = false)
        => isGetDeleted ?
        await _entities.IgnoreQueryFilters().ToListAsync() :
        await _entities.ToListAsync();

    public async Task CreateAsync(T entity,bool isSave = true)
    {
        await _entities.AddAsync(entity);
        await CheckIsSave(isSave);
    }

    public async Task UpdateAsync(T entity,bool isSave = true)
    {
        _entities.Update(entity);
        await CheckIsSave(isSave);
    }

    public async Task DeleteAsync(T entity,bool isSave = true,bool isSoft = true)
    {
        if(isSoft)
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity,isSave);
        }
        else
        {
            _entities.Remove(entity);
            await CheckIsSave(isSave);
        }
    }

    private async Task CheckIsSave(bool isSave)
    {
        if(isSave)
            await _context.SaveChangesAsync();
    }

    public async ValueTask<bool> IsExists(long id)
        => await _entities.AnyAsync(e => e.Id == id);
}