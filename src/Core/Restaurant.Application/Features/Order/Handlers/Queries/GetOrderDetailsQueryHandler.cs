using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Features.Order.Handlers.Queries;

public class GetOrderDetailsQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderDetailsQuery,GetOrderDetailsQueryResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<GetOrderDetailsQueryResponse> Handle(GetOrderDetailsQuery request,CancellationToken cancellationToken)
    {
        bool isOrderAdmin = request.IsMainAdmin ? true : await _orderRepository.CheckOrderBranchAdmin(request.OrderId,request.AdminId);
        if(!isOrderAdmin)
        {
            throw new ForbiddenException("");
        }
        var result = await _orderRepository.GetOrderDetails(request.OrderId) ?? throw new NotFoundException("Order");
        return result;
    }
}