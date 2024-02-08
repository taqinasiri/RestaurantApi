using Restaurant.Application.Features.Product.Common;

namespace Restaurant.Application.Features.Product.Requests.Queries;

public class GetProductsByFilterQuery : IRequest<GetProductsByFilterResponse>
{
    public OrderingModel<ProductOrdering>? Ordering { get; set; } = new(ProductOrdering.Default);
    public PagingRequest Paging { get; set; } = new();
    public ProductFilters Filters { get; set; } = new();
}

#region Filter

public enum ProductOrdering
{
    Default, Title, Slug
}

public record ProductFilters(string? Title = null,string? Slug = null)
{
    public List<long>? CategoryIds { get; set; }
    public List<long>? AvailableInBranchIds { get; set; }
};

#endregion Filter

#region Response

public record class GetProductsByFilterResponse
{
    public List<ProductForFilterList>? Products { get; set; }
    public PagingResponse Paging { get; set; }
}
public record ProductForFilterList(long Id,string Title,string Slug)
{
    public List<CategoryForProductDto>? Categories { get; set; }
}

#endregion Response