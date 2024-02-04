using AutoMapper;

namespace Restaurant.Persistence.Repositories;

public class ProductRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Product> _products = context.Set<Product>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _products.AnyAsync(p => p.Title == title || p.Slug == slug);
}