using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Handlers.Commands;

public class PayOrderCommandHandler(
        IMapper mapper,
    IOrderRepository orderRepository,
    IApplicationUserManager userManager,
    IOptionsMonitor<SiteSettings> options,
    IPaymentService paymentService
    ) : IRequestHandler<PayOrderCommand,PayOrderCommandResponse>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly IPaymentService _paymentService = paymentService;
    private readonly PaymentConfig _paymentConfig = options.CurrentValue.PaymentConfig;

    public async Task<PayOrderCommandResponse> Handle(PayOrderCommand request,CancellationToken cancellationToken)
    {
        var order = await _orderRepository.FindByIdAsync(request.OrderId) ?? throw new NotFoundException("Order");

        if(order.UserId != request.UserId)
        {
            throw new ForbiddenException(Messages.Errors.OrderIsNotForThisUser);
        }

        bool timeIsFree = await _orderRepository.TimeIsFreeForTable(order.FromTime,order.ToTime,order.TableId);
        if(!timeIsFree)
        {
            throw new BadRequestException([Messages.Errors.TimeNotFree]);
        }
        var user = await _userManager.FindByIdAsync(order.UserId.ToString());

        order.Status = OrderStatus.Paying;
        await _orderRepository.UpdateAsync(order);

        var (authority, getewayUrl) = await _paymentService.Payment(order.TotalPrice,_paymentConfig.MerchantId,request.CallbackUrl,user.Email,user.PhoneNumber);
        return new(authority,getewayUrl);
    }
}