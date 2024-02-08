using Restaurant.Application.Features.Product.Common;
using Restaurant.Application.Features.Product.Requests.Commands;
using Restaurant.Application.Features.Product.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductCommand,Product>();
        CreateMap<Product,GetProductDetailsResponse>()
            .ForMember(dest => dest.Images,options => options.MapFrom(src => src.Images.Select(i => i.Image.Name)))
            .ForMember(dest => dest.Categories,options => options.MapFrom(src => src.Categories.Select(c => new CategoryForProductDto(c.Category.Title,c.Category.Id))))
            .ForMember(dest => dest.Branches,options => options.MapFrom(src => src.Branches.Where(b => b.IsAvailable && b.IsActive).Select(b => new BranchForProductDto(b.Branch.Title,b.Price,b.Branch.Id))));
        CreateMap<Product,ProductForFilterList>()
            .ForMember(dest => dest.Categories,options => options.MapFrom(src => src.Categories.Select(c => new CategoryForProductDto(c.Category.Title,c.Category.Id))));
    }
}