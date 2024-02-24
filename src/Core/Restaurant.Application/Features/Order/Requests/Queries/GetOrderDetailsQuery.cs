﻿using Restaurant.Application.Features.Order.Common;
using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Order.Requests.Queries;

public class GetOrderDetailsQuery : IRequest<GetOrderDetailsQueryResponse>
{
    public bool IsMainAdmin { get; set; }
    public long AdminId { get; set; }
    public long OrderId { get; set; }
}

public record GetOrderDetailsQueryResponse(long Id,
    int TotalPrice,
    OrderStatus Status,
    DateTime FromTime,
    DateTime ToTime,
    string Description,
    int RefId,
    long TableId,
    string TableTitle,
    int TableRentalMinutePrice,
    long UserId,
    DateTime? PayDateTime)
{
    public List<OrderItemDetailsDto> Items { get; set; } = null!;
    public string UserName { get; set; } = null!;
};