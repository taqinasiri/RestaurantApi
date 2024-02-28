namespace Restaurant.Persistence.Repositories;

public class BranchWorkingHoursRepository(ApplicationDbContext context) : GenericRepository<BranchWorkingHours>(context), IBranchWorkingHoursRepository
{
    private DbSet<BranchWorkingHours> _workingHours = context.Set<BranchWorkingHours>();

    public async ValueTask<List<BranchWorkingHours>> GetByBranchId(long branchId)
        => await _workingHours.Where(w => w.BranchId == branchId).ToListAsync();
}