using AutoMapper;
using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Persistence.Repositories;

public class BranchRepository(IMapper mapper,ApplicationDbContext context) : GenericRepository<Branch>(context), IBranchRepository
{
    private readonly IMapper _mapper = mapper;
    private DbSet<Branch> _branches = context.Set<Branch>();

    public async ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug)
        => await _branches.AnyAsync(p => p.Title == title || p.Slug == slug);

    public async ValueTask<GetBranchDetailsResponse> GetDetailsById(long id)
        => (await _mapper.ProjectTo<GetBranchDetailsResponse>(_branches.Where(b => b.Id == id)).FirstOrDefaultAsync())!;
}