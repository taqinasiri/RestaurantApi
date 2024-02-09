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

    private async Task CheckIsSave(bool isSave)
    {
        if(isSave)
            await _context.SaveChangesAsync();
    }
}