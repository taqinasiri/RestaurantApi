using Restaurant.Application.Features.Order.Requests.Commands;

namespace Restaurant.Application.Features.Order.Handlers.Commands;

public class VerifyOrderCommandHandler(
    IOrderRepository orderRepository,
    IPaymentService paymentService,
    IOptionsMonitor<SiteSettings> options
    ) : IRequestHandler<VerifyOrderCommand,VerifyOrderCommandResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IPaymentService _paymentServic = paymentService;
    private readonly PaymentConfig _paymentConfig = options.CurrentValue.PaymentConfig;

    public async Task<VerifyOrderCommandResponse> Handle(VerifyOrderCommand request,CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByIdAsync(request.OrderId) ?? throw new NotFoundException("Order");
        var (isSuccess, refId) = await _paymentServic.Verify(order.TotalPrice,_paymentConfig.MerchantId,request.Authority,request.Status);

        if(!isSuccess || refId is null)
        {
            throw new BadRequestException([Messages.Errors.VerifyPaymentFiled]);
        }

        order.RefId = refId.Value;
        order.Status = Domain.Common.OrderStatus.Paid;
        await _orderRepository.UpdateAsync(order);

        return new(refId.Value);
    }
}