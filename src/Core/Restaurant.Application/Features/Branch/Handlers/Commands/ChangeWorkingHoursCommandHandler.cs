using Restaurant.Application.Features.Branch.Requests.Commands;

namespace Restaurant.Application.Features.Branch.Handlers.Commands;

public class ChangeWorkingHoursCommandHandler(
    IMapper mapper,
    IBranchWorkingHoursRepository branchWorkingHoursRepository,
    IBranchRepository branchRepository) : IRequestHandler<ChangeWorkingHoursCommand>
{
    public IMapper _mapper = mapper;
    public IBranchWorkingHoursRepository _branchWorkingHoursRepository = branchWorkingHoursRepository;
    public IBranchRepository _branchRepository = branchRepository;

    public async Task Handle(ChangeWorkingHoursCommand request,CancellationToken cancellationToken)
    {
        bool isExitsBranch = await _branchRepository.IsExists(request.BranchId);
        if(!isExitsBranch)
        {
            throw new NotFoundException("Branch");
        }

        var workingHours = await _branchWorkingHoursRepository.GetByBranchId(request.BranchId);

        workingHours.ForEach(async (item) =>
        {
            await _branchWorkingHoursRepository.DeleteAsync(item,false);
        });
        request.WorkingHours?.ForEach(async (item) =>
        {
            var workingHour = _mapper.Map<BranchWorkingHours>(item);
            workingHour.BranchId = request.BranchId;
            await _branchWorkingHoursRepository.CreateAsync(workingHour,false);
        });

        await _branchWorkingHoursRepository.SaveChangesAsync();
    }
}