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
            .ForMember(dest => dest.Branches,options => options.MapFrom(src => src.Branches.Where(b => b.IsActive).Select(b => new BranchForProductDto(b.Branch.Title,b.Branch.Id,b.IsAvailable))));
        CreateMap<Product,ProductForFilterList>()
            .ForMember(dest => dest.Categories,options => options.MapFrom(src => src.Categories.Select(c => new CategoryForProductDto(c.Category.Title,c.Category.Id))))
            .ForMember(dest => dest.Image,options => options.MapFrom(src => src.Images.FirstOrDefault().Image.Name));
    }
}