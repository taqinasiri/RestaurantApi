using Restaurant.Application.Features.Order.Requests.Queries;
using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    ValueTask<bool> TimeIsFreeForTable(DateTime fromTime,DateTime toTime,long tableId);

    ValueTask<GetByFilterResult<OrderForUserFilterList>> GetUserOrdersByFilterAsync(long userId,OrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering);
}