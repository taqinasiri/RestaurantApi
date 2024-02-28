using AutoMapper;
using Restaurant.Application.Features.Order.Requests.Queries;
using Restaurant.Application.Models;

namespace Restaurant.Persistence.Repositories;

public class OrderRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Order>(context), IOrderRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Order> _orders = context.Set<Order>();

    public async ValueTask<bool> TimeIsFreeForTable(DateTime fromTime,DateTime toTime,long tableId)
        => !(await _orders.AnyAsync(o => o.TableId == tableId && (o.Status == OrderStatus.Paid || o.Status == OrderStatus.Paying) &&
        (o.FromTime < toTime && o.ToTime > fromTime)));

    public async ValueTask<GetByFilterResult<OrderForUserFilterList>> GetUserOrdersByFilterAsync(long userId,UserOrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering)
    {
        var query = _orders.AsQueryable().Where(o => o.UserId == userId);
        if(filter.FromPrice is not null)
            query = query.Where(p => p.TotalPrice >= filter.FromPrice);
        if(filter.ToPrice is not null)
            query = query.Where(p => p.TotalPrice <= filter.ToPrice);

        if(filter.FromDateTime is not null)
            query = query.Where(p => p.FromTime >= filter.FromDateTime);
        if(filter.ToDateTime is not null)
            query = query.Where(p => p.ToTime <= filter.ToDateTime);

        switch(ordering.OrderBy)
        {
            case OrderOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(c => c.Id);
                break;

            case OrderOrdering.TotalPrice:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.TotalPrice) : query.OrderBy(c => c.TotalPrice);
                break;

            case OrderOrdering.PayDateTime:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.PayDateTime) : query.OrderBy(c => c.PayDateTime);
                break;
        }

        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<OrderForUserFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }

    public async ValueTask<GetUserOrderDetailsQueryResponse> GetUserOrderDetails(long orderId)
        => (await _mapper.ProjectTo<GetUserOrderDetailsQueryResponse>(_orders.Where(o => o.Id == orderId)).FirstOrDefaultAsync())!;

    public async ValueTask<bool> CheckOrderForUser(long orderId,long userId)
        => await _orders.AnyAsync(o => o.Id == orderId && o.UserId == userId);

    public async ValueTask<GetByFilterResult<OrderForFilterList>> GetOrdersByFilterAsync(long adminId,bool isMainAdmin,OrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering)
    {
        var query = _orders.AsQueryable();
        if(!isMainAdmin)
            query = query.Where(o => o.Table.Branch.AdminId == adminId);

        if(filter.UserId is not null)
            query = query.Where(p => p.UserId >= filter.UserId);

        if(filter.FromPrice is not null)
            query = query.Where(p => p.TotalPrice >= filter.FromPrice);
        if(filter.ToPrice is not null)
            query = query.Where(p => p.TotalPrice <= filter.ToPrice);

        if(filter.FromDateTime is not null)
            query = query.Where(p => p.FromTime >= filter.FromDateTime);
        if(filter.ToDateTime is not null)
            query = query.Where(p => p.ToTime <= filter.ToDateTime);

        switch(ordering.OrderBy)
        {
            case OrderOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(c => c.Id);
                break;

            case OrderOrdering.TotalPrice:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.TotalPrice) : query.OrderBy(c => c.TotalPrice);
                break;

            case OrderOrdering.PayDateTime:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.PayDateTime) : query.OrderBy(c => c.PayDateTime);
                break;
        }

        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<OrderForFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }

    public async ValueTask<bool> CheckOrderBranchAdmin(long orderId,long adminId)
        => await _orders.AnyAsync(o => o.Id == orderId && o.Table.Branch.AdminId == adminId);

    public async ValueTask<GetOrderDetailsQueryResponse> GetOrderDetails(long orderId)
        => (await _mapper.ProjectTo<GetOrderDetailsQueryResponse>(_orders.Where(o => o.Id == orderId)).FirstOrDefaultAsync())!;
}