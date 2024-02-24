using Restaurant.Application.Features.Order.Common;
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
        CreateMap<Order,OrderForFilterList>();
        CreateMap<OrderItem,OrderItemDetailsDto>()
            .ForMember(dest => dest.Title,options => options.MapFrom(src => src.Product.Title));
        CreateMap<Order,GetUserOrderDetailsQueryResponse>()
            .ForMember(dest => dest.TableTitle,options => options.MapFrom(src => src.Table.Title));
    }
}