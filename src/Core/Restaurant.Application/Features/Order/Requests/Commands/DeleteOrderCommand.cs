﻿namespace Restaurant.Application.Features.Order.Requests.Commands;

public class DeleteOrderCommand : IRequest
{
    public long UserId { get; set; }
    public long OrderId { get; set; }
}