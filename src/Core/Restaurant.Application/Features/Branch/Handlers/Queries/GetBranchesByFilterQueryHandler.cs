using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Application.Features.Branch.Handlers.Queries;

public class GetBranchesByFilterQueryHandler(IBranchRepository branchRepository) : IRequestHandler<GetBranchesByFilterQuery,GetBranchesByFilterResponse>
{
    private readonly IBranchRepository _branchRepository = branchRepository;

    public async Task<GetBranchesByFilterResponse> Handle(GetBranchesByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _branchRepository.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        return new()
        {
            Paging = paging,
            Branches = await _branchRepository.GetByFilterAsync(request.Filters,paging,request.Ordering)
        };
    }
}