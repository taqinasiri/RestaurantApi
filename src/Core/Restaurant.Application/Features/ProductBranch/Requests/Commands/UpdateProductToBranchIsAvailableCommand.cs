namespace Restaurant.Application.Features.ProductBranch.Requests.Commands;

public class UpdateProductToBranchIsAvailableCommand : IRequest
{
    public long ProductId { get; set; }
    public long BranchId { get; set; }
    public bool IsAvailable { get; set; }
}