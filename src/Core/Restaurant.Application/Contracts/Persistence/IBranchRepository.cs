namespace Restaurant.Application.Contracts.Persistence;

public interface IBranchRepository : IGenericRepository<Branch>
{
    ValueTask<bool> IsExistsByTitleOrSlug(string title,string slug);
}