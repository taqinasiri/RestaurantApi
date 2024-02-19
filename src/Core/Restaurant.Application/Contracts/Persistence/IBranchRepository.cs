using Restaurant.Application.Features.Branch.Requests.Queries;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Contracts.Persistence;

public interface IBranchRepository : IGenericRepository<Branch>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetBranchDetailsResponse> GetDetailsById(long id);

    ValueTask<GetByFilterResult<BranchForFilterList>> GetByFilterAsync(BranchFilters filter,PagingQuery paging,OrderingModel<BranchOrdering> ordering);

    ValueTask<bool> BranchIsOpen(long branchId,TimeOnly fromTime,TimeOnly toTime,PersianDayOfWeek dayOfWeek);
}