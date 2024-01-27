using AutoMapper;
using Restaurant.Application.Features.Category.Requests.Queries;
using Restaurant.Application.Models;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.Repositories;

public class CategoryRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Category> _categories = context.Set<Category>();

    public async ValueTask<List<CategoryForFilterList>> GetByFilterAsync(CategoryFilters filter,PagingQuery paging,OrderingModel<CategoryOrdering> ordering)
    {
        var query = _categories.AsQueryable();
        if(filter.Slug!.IsNotNull())
            query = query.Where(c => c.Slug.Contains(filter.Slug!));
        if(filter.Title!.IsNotNull())
            query = query.Where(c => c.Title.Contains(filter.Title!));
        if(filter.ParentId.IsNotNullAndNotZero())
            query = query.Where(c => c.ParentId == filter.ParentId);

        switch(ordering.OrderBy)
        {
            case CategoryOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(c => c.Id);
                break;

            case CategoryOrdering.Title:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Title) : query.OrderBy(c => c.Title);
                break;

            case CategoryOrdering.Slug:
                query = ordering.IsDescending ? query.OrderByDescending(c => c.Slug) : query.OrderBy(c => c.Slug);
                break;
        }

        query = query.Skip(paging.Skip).Take(paging.Take);
        return await _mapper.ProjectTo<CategoryForFilterList>(query).ToListAsync();
    }

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _categories.AnyAsync(c => c.Title == title || c.Slug == slug);
}