namespace Restaurant.Application.Features.Order.Requests.Commands;

public class PayOrderCommand : IRequest<PayOrderCommandResponse>
{
    public long UserId { get; set; }
    public long OrderId { get; set; }
    public string CallbackUrl { get; set; } = null!;
}

public record PayOrderCommandResponse(string Authority);