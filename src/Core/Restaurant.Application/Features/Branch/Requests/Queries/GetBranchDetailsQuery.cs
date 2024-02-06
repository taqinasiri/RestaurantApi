namespace Restaurant.Application.Features.Branch.Requests.Queries;

public class GetBranchDetailsQuery(int id) : IRequest<GetBranchDetailsResponse>
{
    public int Id { get; set; } = id;
}

public record class GetBranchDetailsResponse(long Id,string Title,string? Description,string Slug,string Address)
{
    public List<string>? Images { get; set; }
}