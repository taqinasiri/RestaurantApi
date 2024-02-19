using AutoMapper;
using Restaurant.Application.Features.Branch.Requests.Queries;
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

    public async ValueTask<GetByFilterResult<BranchForFilterList>> GetByFilterAsync(BranchFilters filter,PagingQuery paging,OrderingModel<BranchOrdering> ordering)
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
        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<BranchForFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }

    public async ValueTask<bool> BranchIsOpen(long branchId,TimeOnly fromTime,TimeOnly toTime,PersianDayOfWeek dayOfWeek)
        => await _branches.AnyAsync(b => b.Id == branchId &&
                b.BranchWorkingHours != null &&
                b.BranchWorkingHours.Any(w => w.From <= fromTime && w.To >= toTime && w.DayOfWeek == dayOfWeek));
}