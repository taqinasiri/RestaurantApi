using Restaurant.Application.Contracts.Identity;
using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Handlers.Commands;

public class CreateOrderCommandHandler(
    IMapper mapper,
    IOrderRepository orderRepository,
    IApplicationUserManager userManager,
    ITableRepository tableRepository,
    IBranchRepository branchRepository,
    IProductRepository productRepository,
    IProductBranchRepository productBranchRepository
    ) : IRequestHandler<CreateOrderCommand,CreateOrderCommandResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IApplicationUserManager _userManager = userManager;
    private readonly ITableRepository _tableRepository = tableRepository;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IProductBranchRepository _productBranchRepository = productBranchRepository;

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request,CancellationToken cancellationToken)
    {
        #region Validations

        bool isHasDuringOrder = await _userManager.CheckUserHasDuringOrPayingOrder(request.UserId);
        if(isHasDuringOrder)
        {
            throw new BadRequestException([Messages.Errors.UserHasDuringOrPayingOrder]);
        }

        var table = await _tableRepository.FindByIdAsync(request.TableId) ?? throw new NotFoundException("Table");

        bool branchIsOpen = await _branchRepository.BranchIsOpen(table.BranchId,
            request.FromTime.GetTime(),
            request.ToTime.GetTime(),
            request.FromTime.GetPersianDayOfWeek());
        if(!branchIsOpen)
        {
            throw new BadRequestException([Messages.Errors.BranchClosedInThisTime]);
        }

        bool timeIsFree = await _orderRepository.TimeIsFreeForTable(request.FromTime,request.ToTime,table.Id);
        if(!timeIsFree)
        {
            throw new BadRequestException([Messages.Errors.TimeNotFree]);
        }

        bool isExitsProducts = await _productBranchRepository.IsExitsProductsInBranch(table.BranchId,request.Items?.Select(i => i.ProductId).ToArray()!);
        if(!isExitsProducts)
        {
            throw new NotFoundException("Products in branch");
        }

        #endregion Validations

        #region Calculate Price

        var order = _mapper.Map<Entities.Order>(request);
        order.Status = OrderStatus.During;
        order.TableRentalMinutePrice = table.RentalMinutePrice;

        var time = request.ToTime - request.FromTime;
        int tablePrice = (int)time.TotalMinutes * table.RentalMinutePrice;

        var productsPrices = await _productRepository.GetPrices(request.Items?.Select(i => i.ProductId).ToArray()!);

        int productsTotalPrice = 0;
        order.Items = [];
        foreach(var item in request.Items ?? [])
        {
            int price = productsPrices.First(p => p.ProductId == item.ProductId).Price;
            productsTotalPrice += price * item.Amount;
            order.Items.Add(new()
            {
                Amount = item.Amount,
                UnitPrice = price,
                ProductId = item.ProductId,
            });
        }

        int totalPrice = productsTotalPrice + tablePrice;
        order.TotalPrice = totalPrice;

        #endregion Calculate Price

        await _orderRepository.CreateAsync(order);
        return new(totalPrice);
    }
}