using AutoMapper;
using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Persistence.Repositories;

public class TableRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Table>(context), ITableRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Table> _tables = context.Set<Table>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _tables.AnyAsync(p => p.Title == title || p.Slug == slug);

    public async ValueTask<GetTableDetailsResponse> GetDetailsById(long id)
        => (await _mapper.ProjectTo<GetTableDetailsResponse>(_tables.Where(p => p.Id == id)).FirstOrDefaultAsync())!;
}