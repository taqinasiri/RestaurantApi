using Restaurant.Application.Features.Product.Common;

namespace Restaurant.Application.Features.Product.Requests.Queries;

public class GetProductDetailsQuery(int id) : IRequest<GetProductDetailsResponse>
{
    public int Id { get; set; } = id;
}

public record class GetProductDetailsResponse(long Id,string Title,string? Description,string Slug)
{
    public List<string>? Images { get; set; }
    public List<CategoryForProductDto>? Categories { get; set; }
    public List<BranchForProductDto>? Branches { get; set; }
}