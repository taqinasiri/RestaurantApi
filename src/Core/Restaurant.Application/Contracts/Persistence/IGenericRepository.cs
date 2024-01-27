using Restaurant.Domain.Common;

namespace Restaurant.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : EntityBase
{
    ValueTask<T?> FindByIdAsync(long id,bool isTracking = true);

    ValueTask<IReadOnlyList<T>> GetAllAsync(bool isGetDeleted = false);

    ValueTask<int> GetEntitiesCountAsync();

    ValueTask<bool> IsExists(long id);

    Task UpdateAsync(T entity,bool isSave = true);

    Task DeleteAsync(T entity,bool isSave = true,bool isSoft = true);

    Task CreateAsync(T entity,bool isSave = true);
}