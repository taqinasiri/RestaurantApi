namespace Restaurant.Application.Contracts.Persistence;

public interface ITableRepository : IGenericRepository<Table>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);
}