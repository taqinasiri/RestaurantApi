using Restaurant.Application.Features.Table.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class TableMapping : Profile
{
    public TableMapping()
    {
        CreateMap<CreateTableCommand,Table>();
    }
}