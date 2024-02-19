using Restaurant.Application.Features.Order.Requests.Commands;

namespace Restaurant.Application.Configs.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<CreateOrderCommand,Order>()
            .ForMember(dest => dest.Items,options => options.Ignore());
    }
}