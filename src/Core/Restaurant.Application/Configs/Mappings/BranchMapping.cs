using Restaurant.Application.Features.Branch.Requests.Commands;
using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class BranchMapping : Profile
{
    public BranchMapping()
    {
        CreateMap<CreateBranchCommand,Branch>();
        CreateMap<Branch,GetBranchDetailsResponse>()
            .ForMember(dest => dest.Images,options => options.MapFrom(src => src.Images.Select(i => i.Image.Name)));
        CreateMap<Branch,BranchForFilterList>();
    }
}