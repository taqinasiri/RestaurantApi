﻿using Restaurant.Application.Features.Category.Requests.Commands;
using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryCommand,Category>()
            .ForMember(dest => dest.ParentId,options => options.Ignore());
        CreateMap<Category,GetCategoryDetailsResponse>();
        CreateMap<Category,CategoryForFilterList>()
            .ForMember(dest => dest.ParentTitle,options => options.MapFrom(src => src.Parent.Title));
        CreateMap<Category,CategoryForTree>()
            .ForMember(dest => dest.SubCategories,options => options.Ignore());
    }
}