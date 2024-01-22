namespace Restaurant.Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);
}