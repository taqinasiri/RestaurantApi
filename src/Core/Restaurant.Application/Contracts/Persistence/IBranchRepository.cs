using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Application.Contracts.Persistence;

public interface IBranchRepository : IGenericRepository<Branch>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);

    ValueTask<GetBranchDetailsResponse> GetDetailsById(long id);
}