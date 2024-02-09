using Restaurant.Application.Features.Table.Requests.Queries;

namespace Restaurant.Application.Features.Table.Handlers.Queries;

public class GetTableDetailsQueryHandler(ITableRepository tableRepository) : IRequestHandler<GetTableDetailsQuery,GetTableDetailsResponse>
{
    private readonly ITableRepository _tableRepository = tableRepository;

    public async Task<GetTableDetailsResponse> Handle(GetTableDetailsQuery request,CancellationToken cancellationToken)
    {
        var result = await _tableRepository.GetDetailsById(request.Id) ?? throw new NotFoundException("Table");
        return result;
    }
}