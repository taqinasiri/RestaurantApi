using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface ITableRepository : IGenericRepository<Table>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetTableDetailsResponse> GetDetailsById(long id);

    ValueTask<GetByFilterResult<TableForFilterList>> GetByFilterAsync(TableFilters filter,PagingQuery paging,OrderingModel<TableOrdering> ordering);
}