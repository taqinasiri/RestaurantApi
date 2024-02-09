namespace Restaurant.Application.Features.Table.Requests.Queries;

public class GetTableDetailsQuery(long id) : IRequest<GetTableDetailsResponse>
{
    public long Id { get; set; } = id;
}

public record GetTableDetailsResponse(
    long Id,
    string Title,
    string Slug,
    string? Description,
    byte Space,
    int RentalMinutePrice,
    bool IsAvailable,
    BranchForTableDto Branch);

public record BranchForTableDto(long Id,string Title,string Slug);