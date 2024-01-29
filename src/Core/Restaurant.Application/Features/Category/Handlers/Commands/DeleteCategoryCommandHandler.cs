using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Application.Features.Category.Handlers.Commands;

public class DeleteCategoryCommandHandler(
    ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task Handle(DeleteCategoryCommand request,CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Category");

        await _categoryRepository.DeleteAsync(category);
    }
}