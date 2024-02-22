namespace Restaurant.Persistence.Repositories;

public class OrderRepository(ApplicationDbContext context) : GenericRepository<Order>(context), IOrderRepository
{
    private DbSet<Order> _orders = context.Set<Order>();

    public async ValueTask<bool> TimeIsFreeForTable(DateTime fromTime,DateTime toTime,long tableId)
        => !await _orders.AnyAsync(o => (o.Status == OrderStatus.Paid || o.Status == OrderStatus.Paying) && o.TableId == tableId &&
                !((o.FromTime < fromTime || o.FromTime > toTime) && (o.ToTime > toTime || o.ToTime < fromTime)));
}