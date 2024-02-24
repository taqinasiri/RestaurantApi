using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    ValueTask<bool> TimeIsFreeForTable(DateTime fromTime,DateTime toTime,long tableId);

    ValueTask<GetByFilterResult<OrderForUserFilterList>> GetUserOrdersByFilterAsync(long userId,UserOrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering);

    ValueTask<GetByFilterResult<OrderForFilterList>> GetOrdersByFilterAsync(long adminId,bool isMainAdmin,OrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering);

    ValueTask<GetUserOrderDetailsQueryResponse> GetUserOrderDetails(long orderId);

    ValueTask<GetOrderDetailsQueryResponse> GetOrderDetails(long orderId);

    ValueTask<bool> CheckOrderForUser(long orderId,long userId);

    ValueTask<bool> CheckOrderBranchAdmin(long orderId,long adminId);
}