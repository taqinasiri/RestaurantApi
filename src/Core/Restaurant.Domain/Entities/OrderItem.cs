namespace Restaurant.Domain.Entities;

[Table("OrderItems")]
public class OrderItem : EntityBase
{
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public int UnitPrice { get; set; }
    public int Amount { get; set; }

    [NotMapped]
    public int FinalPrice => UnitPrice * Amount;

    #region Relations

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;

    #endregion Relations
}