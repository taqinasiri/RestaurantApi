using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Application.Features.ProductBranch.Handlers.Commands;

public class UpdateProductToBranchPriceCommandHandler(IProductBranchRepository productBranchRepository) : IRequestHandler<UpdateProductToBranchPriceCommand>
{
    private readonly IProductBranchRepository _productBranchRepository = productBranchRepository;

    public async Task Handle(UpdateProductToBranchPriceCommand request,CancellationToken cancellationToken)
    {
        var productToBranch = await _productBranchRepository.FindByIdsAsync(request.ProductId,request.BranchId) ?? throw new NotFoundException("Product To Branch");

        productToBranch.Price = request.Price;

        await _productBranchRepository.UpdateAsync(productToBranch);
    }
}