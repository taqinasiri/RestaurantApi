using Restaurant.Application.Features.Branch.Common;

namespace Restaurant.Application.Features.Branch.Requests.Commands;

public class ChangeWorkingHoursCommand : IRequest
{
    public long BranchId { get; set; }
    public List<WorkingHoursDto>? WorkingHours { get; set; }
}