using AutoMapper;
using Restaurant.Application.Features.Product.Requests.Queries;
using Restaurant.Application.Models;

namespace Restaurant.Persistence.Repositories;

public class ProductRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Product> _products = context.Set<Product>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _products.AnyAsync(p => p.Title == title || p.Slug == slug);

    public async ValueTask<GetProductDetailsResponse> GetDetailsById(int id)
        => (await _mapper.ProjectTo<GetProductDetailsResponse>(_products.Where(p => p.Id == id)).FirstOrDefaultAsync())!;

    public async ValueTask<GetByFilterResult<ProductForFilterList>> GetByFilterAsync(ProductFilters filter,PagingQuery paging,OrderingModel<ProductOrdering> ordering)
    {
        var query = _products.AsQueryable();
        if(filter.Slug!.IsNotNull())
            query = query.Where(p => p.Slug.Contains(filter.Slug!));
        if(filter.Title!.IsNotNull())
            query = query.Where(p => p.Title.Contains(filter.Title!));
        if(filter.FromPrice is not null)
            query = query.Where(p => p.Price >= filter.FromPrice);
        if(filter.ToPrice is not null)
            query = query.Where(p => p.Price <= filter.ToPrice);

        if(filter.CategoryIds?.Count > 0)
            query = query.Where(p => p.Categories.Any(c => filter.CategoryIds.Contains(c.Category.Id)));

        if(filter.AvailableInBranchIds?.Count > 0)
            query = query.Where(p => p.Branches.Any(b => b.IsActive && filter.AvailableInBranchIds.Contains(b.Branch.Id)));
        if(filter.IsAvailable is not null)
            query = query.Where(p => p.Branches.Any(b => b.IsAvailable == filter.IsAvailable));

        switch(ordering.OrderBy)
        {
            case ProductOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(c => c.Id);
                break;

            case ProductOrdering.Title:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Title) : query.OrderBy(c => c.Title);
                break;

            case ProductOrdering.Slug:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Slug) : query.OrderBy(c => c.Slug);
                break;

            case ProductOrdering.Price:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Price) : query.OrderBy(c => c.Price);
                break;
        }

        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<ProductForFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }

    public async Task<Product?> FindWithCategoriesByIdAsync(long id,bool isTracking = true)
        => await _products.Include(p => p.Categories).ThenInclude(c => c.Category).SingleOrDefaultAsync(c => c.Id == id);

    public async ValueTask<List<(long ProductId, int Price)>> GetPrices(long[] ids)
        => await _products
        .Where(p => ids.Contains(p.Id))
        .Select(p => new ValueTuple<long,int>(p.Id,p.Price))
        .ToListAsync();
}