﻿using AutoMapper;
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

    public async ValueTask<GetByFilterResult<OrderForUserFilterList>> GetUserOrdersByFilterAsync(long userId,OrderFilters filter,PagingQuery paging,OrderingModel<OrderOrdering> ordering)
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
}