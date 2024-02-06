using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class BranchMapping : Profile
{
    public BranchMapping()
    {
        CreateMap<CreateBranchCommand,Branch>();
    }
}