using Restaurant.Application.Features.Table.Common;
using Restaurant.Application.Features.Table.Requests.Commands;
using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class TableMapping : Profile
{
    public TableMapping()
    {
        CreateMap<CreateTableCommand,Table>();
        CreateMap<Branch,BranchForTableDto>();
        CreateMap<Table,GetTableDetailsResponse>()
            .ForMember(dest => dest.Branch,options => options.MapFrom(src => src.Branch));
        CreateMap<Table,TableForFilterList>()
            .ForMember(dest => dest.Branch,options => options.MapFrom(src => src.Branch));
    }
}