using Restaurant.Application.Features.Branch.Common;
using Restaurant.Application.Features.Branch.Requests.Commands;
using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class BranchMapping : Profile
{
    public BranchMapping()
    {
        CreateMap<CreateBranchCommand,Branch>();
        CreateMap<Branch,GetBranchDetailsResponse>()
            .ForMember(dest => dest.Images,options => options.MapFrom(src => src.Images.Select(i => i.Image.Name)))
            .ForMember(dest => dest.WorkingHoursDtos,options => options.MapFrom(src => src.BranchWorkingHours));
        CreateMap<Branch,BranchForFilterList>();
        CreateMap<WorkingHoursDto,BranchWorkingHours>().ReverseMap();
    }
}