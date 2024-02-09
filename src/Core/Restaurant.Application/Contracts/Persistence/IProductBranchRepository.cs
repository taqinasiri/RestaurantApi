namespace Restaurant.Application.Contracts.Persistence;

public interface IProductBranchRepository
{
    Task AddAsync(ProductToBranch productToBranch,bool isSave = true);

    ValueTask<bool> IsExists(long productId,long branchId);
}