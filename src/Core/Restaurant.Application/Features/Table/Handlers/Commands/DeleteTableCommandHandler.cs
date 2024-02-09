using Restaurant.Application.Features.Table.Requests.Commands;

namespace Restaurant.Application.Features.Table.Handlers.Commands;

public class DeleteTableCommandHandler(ITableRepository tableRepository) : IRequestHandler<DeleteTableCommand>
{
    private readonly ITableRepository _tableRepository = tableRepository;

    public async Task Handle(DeleteTableCommand request,CancellationToken cancellationToken)
    {
        var table = await _tableRepository.FindByIdAsync(request.Id) ?? throw new NotFoundException("Table");
        await _tableRepository.DeleteAsync(table);
    }
}