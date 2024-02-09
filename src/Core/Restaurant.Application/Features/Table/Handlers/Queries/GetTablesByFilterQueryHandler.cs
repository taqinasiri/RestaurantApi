using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Application.Features.Table.Handlers.Queries;

public class GetTablesByFilterQueryHandler(ITableRepository tableRepository) : IRequestHandler<GetTablesByFilterQuery,GetTablesByFilterResponse>
{
    private readonly ITableRepository _tableRepository = tableRepository;

    public async Task<GetTablesByFilterResponse> Handle(GetTablesByFilterQuery request,CancellationToken cancellationToken)
    {
        int entitiesCount = await _tableRepository.GetEntitiesCountAsync();
        var paging = request.Paging.ToPaging(entitiesCount);

        var products = await _tableRepository.GetByFilterAsync(request.Filters,paging,request.Ordering);

        paging.ResultsCount = products.ResultsCount;

        return new()
        {
            Paging = paging,
            Tables = products.Data
        };
    }
}