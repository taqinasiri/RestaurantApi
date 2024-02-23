using Restaurant.Application.Features.Order.Requests.Commands;
using Restaurant.Application.Features.Order.Requests.Queries;

namespace Restaurant.Application.Configs.Mappings;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<CreateOrderCommand,Order>()
            .ForMember(dest => dest.Items,options => options.Ignore());
        CreateMap<Order,OrderForUserFilterList>();
    }
}