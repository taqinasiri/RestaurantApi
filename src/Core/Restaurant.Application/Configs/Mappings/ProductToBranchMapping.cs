using Restaurant.Application.Features.ProductBranch.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class ProductToBranchMapping : Profile
{
    public ProductToBranchMapping()
    {
        CreateMap<AddProductToBranchCommand,ProductToBranch>();
    }
}