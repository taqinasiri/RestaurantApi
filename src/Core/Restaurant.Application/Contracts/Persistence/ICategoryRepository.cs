using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetByFilterResult<CategoryForFilterList>> GetByFilterAsync(CategoryFilters filter,PagingQuery paging,OrderingModel<CategoryOrdering> ordering);
}