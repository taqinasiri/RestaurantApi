namespace Restaurant.Application.Features.ProductBranch.Requests.Commands;

public class AddProductToBranchCommand : IRequest
{
    public long ProductId { get; set; }
    public long BranchId { get; set; }
    public int Price { get; set; }
}