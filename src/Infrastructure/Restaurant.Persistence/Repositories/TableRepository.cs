using AutoMapper;
using Restaurant.Application.Features.Table.Requests.Queries;
using Restaurant.Application.Models;

namespace Restaurant.Persistence.Repositories;

public class TableRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Table>(context), ITableRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Table> _tables = context.Set<Table>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _tables.AnyAsync(p => p.Title == title || p.Slug == slug);

    public async ValueTask<GetTableDetailsResponse> GetDetailsById(long id)
        => (await _mapper.ProjectTo<GetTableDetailsResponse>(_tables.Where(p => p.Id == id)).FirstOrDefaultAsync())!;

    public async ValueTask<GetByFilterResult<TableForFilterList>> GetByFilterAsync(TableFilters filter,PagingQuery paging,OrderingModel<TableOrdering> ordering)
    {
        var query = _tables.AsQueryable();
        if(filter.Slug!.IsNotNull())
            query = query.Where(p => p.Slug.Contains(filter.Slug!));
        if(filter.Title!.IsNotNull())
            query = query.Where(p => p.Title.Contains(filter.Title!));
        if(filter.IsAvailable is not null)
            query = query.Where(p => p.IsAvailable == filter.IsAvailable);
        if(filter.Space is not null and not 0)
            query = query.Where(p => p.Space == filter.Space);
        if(filter.BranchId is not null and not 0)
            query = query.Where(p => p.BranchId == filter.BranchId);

        switch(ordering.OrderBy)
        {
            case TableOrdering.Default:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(t => t.Id);
                break;

            case TableOrdering.Title:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(t => t.Title);
                break;

            case TableOrdering.Slug:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(t => t.Slug);
                break;

            case TableOrdering.Space:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(t => t.Space);
                break;

            case TableOrdering.Branch:
                if(ordering.IsDescending)
                    query = query.OrderByDescending(t => t.BranchId);
                break;
        }

        var resultsCount = await query.CountAsync();
        query = query.Skip(paging.Skip).Take(paging.Take);
        return new()
        {
            Data = await _mapper.ProjectTo<TableForFilterList>(query).ToListAsync(),
            ResultsCount = resultsCount,
        };
    }
}