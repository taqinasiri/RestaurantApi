using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Application.Features.ProductBranch.Handlers.Commands;

public class UpdateProductToBranchIsActiveCommandHandler(IProductBranchRepository productBranchRepository) : IRequestHandler<UpdateProductToBranchIsActiveCommand>
{
    private readonly IProductBranchRepository _productBranchRepository = productBranchRepository;

    public async Task Handle(UpdateProductToBranchIsActiveCommand request,CancellationToken cancellationToken)
    {
        var productToBranch = await _productBranchRepository.FindByIdsAsync(request.ProductId,request.BranchId) ?? throw new NotFoundException("Product To Branch");

        productToBranch.IsActive = request.IsActive;

        await _productBranchRepository.UpdateAsync(productToBranch);
    }
}