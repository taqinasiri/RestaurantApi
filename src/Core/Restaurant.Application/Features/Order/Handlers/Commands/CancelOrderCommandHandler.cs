using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Handlers.Commands;

public class CancelOrderCommandHandler(
    IOrderRepository orderRepository
    ) : IRequestHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task Handle(CancelOrderCommand request,CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByIdAsync(request.OrderId) ?? throw new NotFoundException("Order");

        if(order.UserId != request.UserId)
        {
            throw new ForbiddenException(Messages.Errors.OrderIsNotForThisUser);
        }

        if(order.Status is OrderStatus.Canceled)
        {
            return;
        }

        if(order.Status is OrderStatus.Paid)
        {
            throw new BadRequestException([Messages.Errors.OrderPaid]);
        }

        order.Status = OrderStatus.Canceled;
        await _orderRepository.UpdateAsync(order);
    }
}