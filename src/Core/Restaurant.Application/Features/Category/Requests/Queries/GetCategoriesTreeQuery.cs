namespace Restaurant.Application.Features.Category.Requests.Queries;

public class GetCategoriesTreeQuery : IRequest<GetCategoriesTreeResponse>
{
    public byte Depth { get; set; }
}

public record GetCategoriesTreeResponse()
{
    public List<CategoryForTree> Categories { get; set; } = [];
}
public record CategoryForTree(long Id,string Title,string Slug,string? Picture)
{
    public List<CategoryForTree>? SubCategories { get; set; }
};