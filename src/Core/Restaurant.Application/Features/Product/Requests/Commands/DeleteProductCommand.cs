namespace Restaurant.Application.Features.Product.Requests.Commands;

public class DeleteProductCommand(long Id) : IRequest
{
    public long Id { get; set; } = Id;
}