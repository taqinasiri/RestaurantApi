using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Features.Order.Handlers.Queries;

public class GetUserOrdersQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetUserOrdersByFilterQuery,GetUserOrdersByFilterResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<GetUserOrdersByFilterResponse> Handle(GetUserOrdersByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _orderRepository.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        var orders = await _orderRepository.GetUserOrdersByFilterAsync(request.UserId,request.Filters,paging,request.Ordering);

        paging.ResultsCount = orders.ResultsCount;

        return new()
        {
            Paging = paging,
            Orders = orders.Data
        };
    }
}