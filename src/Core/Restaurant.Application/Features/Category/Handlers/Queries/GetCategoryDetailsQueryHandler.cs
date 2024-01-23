using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Features.Category.Handlers.Queries;

public class GetCategoryDetailsQueryHandler(IMapper mapper,ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryDetailsQuery,GetCategoryDetailsResponse>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GetCategoryDetailsResponse> Handle(GetCategoryDetailsQuery request,CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Category");
        var result = _mapper.Map<GetCategoryDetailsResponse>(category);
        return result;
    }
}