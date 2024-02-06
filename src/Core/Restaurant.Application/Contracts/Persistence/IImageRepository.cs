namespace Restaurant.Application.Contracts.Persistence;

public interface IImageRepository : IGenericRepository<Image>
{
    ValueTask<Image> FindByNameAsync(string name);

    ValueTask<Image> FindForBranch(string name,long branchId);
}