using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Features.Product.Handlers.Queries;

public class GetProductsByFilterQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsByFilterQuery,GetProductsByFilterResponse>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<GetProductsByFilterResponse> Handle(GetProductsByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _productRepository.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        var products = await _productRepository.GetByFilterAsync(request.Filters,paging,request.Ordering);

        paging.ResultsCount = products.ResultsCount;

        return new()
        {
            Paging = paging,
            Products = products.Data
        };
    }
}