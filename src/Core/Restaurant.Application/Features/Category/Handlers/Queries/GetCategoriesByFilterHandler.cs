using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Features.Category.Handlers.Queries;

public class GetCategoriesByFilterHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesByFilterQuery,GetCategoriesByFilterResponse>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<GetCategoriesByFilterResponse> Handle(GetCategoriesByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _categoryRepository.GetEntitiesCountAsync();

        var paging = request.Paging.ToPaging(entitiesCount);

        var categories = await _categoryRepository.GetByFilterAsync(request.Filters,paging,request.Ordering);

        paging.ResultsCount = categories.ResultsCount;

        return new()
        {
            Paging = paging,
            Categories = categories.Data
        };
    }
}