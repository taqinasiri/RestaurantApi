using Restaurant.Application.Features.Product.Requests.Commands;

namespace Restaurant.Application.Features.Product.Handlers.Commands;

public class DeleteProductCommandHandler(
    IProductRepository productRepository) : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(DeleteProductCommand request,CancellationToken cancellationToken)
    {
        var category = await _productRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Product");
        await _productRepository.DeleteAsync(category);
    }
}