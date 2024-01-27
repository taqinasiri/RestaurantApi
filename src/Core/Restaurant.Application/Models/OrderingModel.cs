namespace Restaurant.Application.Models;

public record OrderingModel<OrderingFields>(OrderingFields? OrderBy,bool IsDescending = true) where OrderingFields : Enum
{
    public bool IsDescending { get; set; } = IsDescending;
    public OrderingFields? OrderBy { get; set; } = OrderBy;
}