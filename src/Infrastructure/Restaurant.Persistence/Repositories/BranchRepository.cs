using AutoMapper;
using Restaurant.Application.Features.Branch.Requests.Queries;
using Restaurant.Application.Features.Category.Requests.Queries;
using Restaurant.Application.Models;

namespace Restaurant.Persistence.Repositories;

public class BranchRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Branch>(context), IBranchRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Branch> _branches = context.Set<Branch>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _branches.AnyAsync(p => p.Title == title || p.Slug == slug);

    public async ValueTask<GetBranchDetailsResponse> GetDetailsById(long id)
        => (await _mapper.ProjectTo<GetBranchDetailsResponse>(_branches.Where(b => b.Id == id)).FirstOrDefaultAsync())!;

    public async ValueTask<List<BranchForFilterList>> GetByFilterAsync(BranchFilters filter,PagingQuery paging,OrderingModel<BranchOrdering> ordering)
    {
        {
            var query = _branches.AsQueryable();
            if(filter.Slug!.IsNotNull())
                query = query.Where(c => c.Slug.Contains(filter.Slug!));
            if(filter.Title!.IsNotNull())
                query = query.Where(c => c.Title.Contains(filter.Title!));
            if(filter.Address!.IsNotNull())
                query = query.Where(c => c.Address.Contains(filter.Address!));

            switch(ordering.OrderBy)
            {
                case BranchOrdering.Default:
                    if(ordering.IsDescending)
                        query = query.OrderByDescending(c => c.Id);
                    break;

                case BranchOrdering.Title:
                    query = ordering.IsDescending ? query.OrderByDescending(c => c.Title) : query.OrderBy(c => c.Title);
                    break;

                case BranchOrdering.Slug:
                    query = ordering.IsDescending ? query.OrderByDescending(c => c.Slug) : query.OrderBy(c => c.Slug);
                    break;
            }

            query = query.Skip(paging.Skip).Take(paging.Take);
            return await _mapper.ProjectTo<BranchForFilterList>(query).ToListAsync();
        }
    }
}