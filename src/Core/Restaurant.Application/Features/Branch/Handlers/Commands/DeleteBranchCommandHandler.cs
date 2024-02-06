using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Application.Features.Branch.Handlers.Commands;

internal class DeleteBranchCommandHandler(
    IBranchRepository branchRepository) : IRequestHandler<DeleteBranchCommand>
{
    private readonly IBranchRepository _branchRepository = branchRepository;

    public async Task Handle(DeleteBranchCommand request,CancellationToken cancellationToken)
    {
        var category = await _branchRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Branch");
        await _branchRepository.DeleteAsync(category);
    }
}