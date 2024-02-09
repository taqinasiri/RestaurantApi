using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Application.Features.ProductBranch.Handlers.Commands;

public class UpdateProductToBranchIsAvailableCommandHandler(IProductBranchRepository productBranchRepository) : IRequestHandler<UpdateProductToBranchIsAvailableCommand>
{
    private readonly IProductBranchRepository _productBranchRepository = productBranchRepository;

    public async Task Handle(UpdateProductToBranchIsAvailableCommand request,CancellationToken cancellationToken)
    {
        var productToBranch = await _productBranchRepository.FindByIdsAsync(request.ProductId,request.BranchId) ?? throw new NotFoundException("Product To Branch");

        productToBranch.IsAvailable = request.IsAvailable;

        await _productBranchRepository.UpdateAsync(productToBranch);
    }
}