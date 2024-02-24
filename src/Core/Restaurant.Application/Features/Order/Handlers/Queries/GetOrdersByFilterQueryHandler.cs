using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Features.Order.Handlers.Queries;

public class GetOrdersByFilterQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrdersByFilterQuery,GetOrdersByFilterResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<GetOrdersByFilterResponse> Handle(GetOrdersByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _orderRepository.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        var orders = await _orderRepository.GetOrdersByFilterAsync(request.AdminId,request.IsMainAdmin,request.Filters,paging,request.Ordering);

        paging.ResultsCount = orders.ResultsCount;

        return new()
        {
            Paging = paging,
            Orders = orders.Data
        };
    }
}