using Restaurant.Application.Features.Category.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryCommand,Category>()
            .ForMember(dest => dest.ParentId,config => config.Ignore());
    }
}