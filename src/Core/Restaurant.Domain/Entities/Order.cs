using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Entities;

public class Order : EntityBase
{
    public long UserId { get; set; }

    public long TableId { get; set; }
    public int TableRentalMinutePrice { get; set; }

    public DateTime FromTime { get; set; }
    public DateTime ToTime { get; set; }

    public int TotalPrice { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public OrderStatus Status { get; set; }
    public int RefId { get; set; }

    #region Relations

    public Table Table { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<OrderItem> Items { get; set; } = null!;

    #endregion Relations
}