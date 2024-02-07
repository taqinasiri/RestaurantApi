using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Features.Product.Handlers.Queries;

public class GetProductDetailsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductDetailsQuery,GetProductDetailsResponse>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductDetailsResponse> Handle(GetProductDetailsQuery request,CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetDetailsById(request.Id) ?? throw new NotFoundException("Product");
        return result;
    }
}