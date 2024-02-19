namespace Restaurant.Application.Contracts.Persistence;

public interface IProductBranchRepository
{
    Task AddAsync(ProductToBranch productToBranch,bool isSave = true);

    ValueTask<ProductToBranch> FindByIdsAsync(long productId,long branchId);

    ValueTask<bool> IsExists(long productId,long branchId);

    Task UpdateAsync(ProductToBranch productToBranch,bool isSave = true);

    ValueTask<bool> IsExitsProductsInBranch(long branchId,long[] productIds);
}