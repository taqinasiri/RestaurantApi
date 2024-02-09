namespace Restaurant.Application.Features.ProductBranch.Requests.Commands;

public class UpdateProductToBranchIsActiveCommand : IRequest
{
    public long ProductId { get; set; }
    public long BranchId { get; set; }
    public bool IsActive { get; set; }
}