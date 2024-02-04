using Restaurant.Application.Features.Product.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<CreateProductCommand,Product>();
    }
}