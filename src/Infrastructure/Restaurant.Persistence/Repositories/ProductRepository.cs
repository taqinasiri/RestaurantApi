using AutoMapper;
using Restaurant.Application.Features.Product.Requests.Queries;
using Restaurant.Application.Helpers;
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

    public async ValueTask<List<ProductForFilterList>> GetByFilterAsync(ProductFilters filter,Paging paging,OrderingModel<ProductOrdering> ordering)
    {
        var query = _products.AsQueryable();
        if(filter.Slug!.IsNotNull())
            query = query.Where(p => p.Slug.Contains(filter.Slug!));
        if(filter.Title!.IsNotNull())
            query = query.Where(p => p.Title.Contains(filter.Title!));
        if(filter.CategoryIds?.Count > 0)
            query = query.Where(p => p.Categories.Any(c => filter.CategoryIds.Contains(c.Category.Id)));
        if(filter.AvailableInBranchIds?.Count > 0)
            query = query.Where(p => p.Branches.Any(b => b.IsAvailable && filter.AvailableInBranchIds.Contains(b.Branch.Id)));

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
        }

        query = query.Skip(paging.Skip).Take(paging.Take);
        return await _mapper.ProjectTo<ProductForFilterList>(query).ToListAsync();
    }
}