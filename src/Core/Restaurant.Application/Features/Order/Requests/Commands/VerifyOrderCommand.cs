namespace Restaurant.Application.Features.Order.Requests.Commands;

public class VerifyOrderCommand : IRequest<VerifyOrderCommandResponse>
{
    public long OrderId { get; set; }
    public string Authority { get; set; } = null!;
    public string Status { get; set; } = null!;
}

public record VerifyOrderCommandResponse(int RefId);