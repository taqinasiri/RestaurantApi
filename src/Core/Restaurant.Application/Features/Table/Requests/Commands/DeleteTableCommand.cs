namespace Restaurant.Application.Features.Table.Requests.Commands;

public class DeleteTableCommand(long Id) : IRequest
{
    public long Id { get; set; } = Id;
}