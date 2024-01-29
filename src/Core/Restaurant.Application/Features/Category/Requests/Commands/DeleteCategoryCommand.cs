namespace Restaurant.Application.Features.Category.Requests.Commands;

public class DeleteCategoryCommand : IRequest
{
    public long Id { get; set; }
}