namespace Restaurant.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);
}