namespace Restaurant.Application.Features.Branch.Requests.Commands;

public class DeleteBranchCommand(long Id) : IRequest
{
    public long Id { get; set; } = Id;
}