using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Features.Order.Handlers.Queries;

public class GetUserOrderDetailsQueryHandler(
    IOrderRepository orderRepository
    ) : IRequestHandler<GetUserOrderDetailsQuery,GetUserOrderDetailsQueryResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<GetUserOrderDetailsQueryResponse> Handle(GetUserOrderDetailsQuery request,CancellationToken cancellationToken)
    {
        bool orderForUser = await _orderRepository.CheckOrderForUser(request.OrderId,request.UserId);
        if(!orderForUser)
        {
            throw new ForbiddenException(Messages.Errors.OrderIsNotForThisUser);
        }
        var result = await _orderRepository.GetUserOrderDetails(request.OrderId);
        return result;
    }
}