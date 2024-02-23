using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Handlers.Commands;

public class DeleteOrderCommandHandler(
    IOrderRepository orderRepository
    ) : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task Handle(DeleteOrderCommand request,CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByIdAsync(request.OrderId) ?? throw new NotFoundException("Order");

        if(order.UserId != request.UserId)
        {
            throw new ForbiddenException(Messages.Errors.OrderIsNotForThisUser);
        }

        if(order.Status is not OrderStatus.During)
        {
            throw new BadRequestException([Messages.Errors.OnlyDuringOrdersCanBeDeleted]);
        }

        await _orderRepository.DeleteAsync(order);
    }
}