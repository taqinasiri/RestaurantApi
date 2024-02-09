namespace Restaurant.Application.Features.ProductBranch.Requests.Commands;

public class UpdateProductToBranchPriceCommand : IRequest
{
    public long ProductId { get; set; }
    public long BranchId { get; set; }
    public int Price { get; set; }
}