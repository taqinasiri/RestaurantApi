using Restaurant.Application.Features.Branch.Requests.Queries;
using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IBranchRepository : IGenericRepository<Branch>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetBranchDetailsResponse> GetDetailsById(long id);

    ValueTask<List<BranchForFilterList>> GetByFilterAsync(BranchFilters filter,PagingQuery paging,OrderingModel<BranchOrdering> ordering);
}