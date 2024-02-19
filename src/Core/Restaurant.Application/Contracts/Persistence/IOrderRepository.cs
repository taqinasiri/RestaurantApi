namespace Restaurant.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    ValueTask<bool> TimeIsFreeForTable(DateTime fromTime,DateTime toTime,long tableId);
}