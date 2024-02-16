namespace Restaurant.Application.Contracts.Persistence;

public interface IBranchWorkingHoursRepository : IGenericRepository<BranchWorkingHours>
{
    ValueTask<List<BranchWorkingHours>> GetByBranchId(long branchId);
}