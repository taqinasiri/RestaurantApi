namespace Restaurant.Persistence.Repositories;

public class ProductBranchRepository(ApplicationDbContext context) : IProductBranchRepository
{
    private readonly ApplicationDbContext _context = context;
    private DbSet<ProductToBranch> _productToBranches = context.Set<ProductToBranch>();

    public async Task AddAsync(ProductToBranch productToBranch,bool isSave = true)
    {
        await _productToBranches.AddAsync(productToBranch);
        await CheckIsSave(isSave);
    }

    public async ValueTask<bool> IsExists(long productId,long branchId)
        => await _productToBranches.AnyAsync(p => p.ProductId == productId && p.BranchId == branchId);

    public async ValueTask<ProductToBranch> FindByIdsAsync(long productId,long branchId)
        => (await _productToBranches.SingleOrDefaultAsync(p => p.ProductId == productId && p.BranchId == branchId))!;

    private async Task CheckIsSave(bool isSave)
    {
        if(isSave)
            await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductToBranch productToBranch,bool isSave = true)
    {
        _productToBranches.Update(productToBranch);
        await CheckIsSave(isSave);
    }

    public async ValueTask<bool> IsExitsProductsInBranch(long branchId,long[] productIds)
        => (await _productToBranches
        .Where(pb => pb.BranchId == branchId && pb.IsActive && pb.IsAvailable)
        .Select(pb => pb.ProductId)
        .Intersect(productIds)
        .CountAsync()) == productIds.Length;
}