using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Application.Features.ProductBranch.Handlers.Commands;

public class AddProductToBranchCommandHandler(
    IMapper mapper,
    IProductRepository productRepository,
    IBranchRepository branchRepository,
    IProductBranchRepository productBranchRepository) : IRequestHandler<AddProductToBranchCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IBranchRepository _branchRepository = branchRepository;
    private readonly IProductBranchRepository _productBranchRepository = productBranchRepository;

    public async Task Handle(AddProductToBranchCommand request,CancellationToken cancellationToken)
    {
        bool isExitsProduct = await _productRepository.IsExists(request.ProductId);
        if(!isExitsProduct)
        {
            throw new NotFoundException("Product");
        }

        bool isExitsBranch = await _branchRepository.IsExists(request.BranchId);
        if(!isExitsBranch)
        {
            throw new NotFoundException("Branch");
        }

        bool isExitsProductToBranch = await _productBranchRepository.IsExists(request.ProductId,request.BranchId);
        if(isExitsProductToBranch)
        {
            return;
        }

        var productToBranch = _mapper.Map<ProductToBranch>(request);

        productToBranch.IsAvailable = true;
        productToBranch.IsActive = true;

        await _productBranchRepository.AddAsync(productToBranch);
    }
}