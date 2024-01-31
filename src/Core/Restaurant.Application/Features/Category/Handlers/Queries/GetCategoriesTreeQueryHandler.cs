using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Features.Category.Handlers.Queries;

public class GetCategoriesTreeQueryHandler(IMapper mapper,ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesTreeQuery,GetCategoriesTreeResponse>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GetCategoriesTreeResponse> Handle(GetCategoriesTreeQuery request,CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        var result = BuildTree([.. categories],overallDepth: request.Depth);
        return new() { Categories = result };
    }

    private List<CategoryForTree> BuildTree(List<Entities.Category> categories,long? parentId = null,int overallDepth = 1,int currentDepth = 0)
    {
        var result = new List<CategoryForTree>();
        currentDepth++;
        foreach(var category in categories)
        {
            if(category.ParentId == parentId && overallDepth >= currentDepth)
            {
                List<CategoryForTree>? subCategories = null;
                if(category.Children is not null)
                    subCategories = BuildTree([.. category.Children],category.Id,overallDepth,currentDepth);

                var addItem = _mapper.Map<CategoryForTree>(category);
                addItem.SubCategories = subCategories;
                result.Add(addItem);
            }
        }
        return result;
    }
}