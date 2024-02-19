using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    ValueTask<GetProductDetailsResponse> GetDetailsById(int id);

    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetByFilterResult<ProductForFilterList>> GetByFilterAsync(ProductFilters filter,PagingQuery paging,OrderingModel<ProductOrdering> ordering);

    Task<Product?> FindWithCategoriesByIdAsync(long id,bool isTracking = true);

    ValueTask<List<(long ProductId, int Price)>> GetPrices(long[] ids);
}