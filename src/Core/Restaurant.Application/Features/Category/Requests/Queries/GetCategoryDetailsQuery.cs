namespace Restaurant.Application.Features.Category.Requests.Queries;

public class GetCategoryDetailsQuery(int id) : IRequest<GetCategoryDetailsResponse>
{
    public int Id { get; set; } = id;
}

public record class GetCategoryDetailsResponse(int Id,string Title,string? Description,string Slug,long? ParentId);