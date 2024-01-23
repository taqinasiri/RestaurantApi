﻿using Restaurant.Application.Features.Category.Requests.Commands;
using Restaurant.Application.Features.Category.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<CreateCategoryCommand,Category>()
            .ForMember(dest => dest.ParentId,config => config.Ignore());
        CreateMap<Category,GetCategoryDetailsResponse>();
    }
}