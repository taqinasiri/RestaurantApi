using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    ValueTask<GetProductDetailsResponse> GetDetailsById(int id);

    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<List<ProductForFilterList>> GetByFilterAsync(ProductFilters filter,Paging paging,OrderingModel<ProductOrdering> ordering);
}