using Restaurant.Application.Features.Branch.Requests.Queries;

namespace Restaurant.Application.Features.Branch.Handlers.Queries;

public class GetBranchDetailsQueryHandler(IBranchRepository branchRepository) : IRequestHandler<GetBranchDetailsQuery,GetBranchDetailsResponse>
{
    private readonly IBranchRepository _branchRepository = branchRepository;

    public async Task<GetBranchDetailsResponse> Handle(GetBranchDetailsQuery request,CancellationToken cancellationToken)
    {
        var result = await _branchRepository.GetDetailsById(request.Id) ?? throw new NotFoundException("Category");
        return result;
    }
}