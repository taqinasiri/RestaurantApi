using Restaurant.Domain.Common;

namespace Restaurant.Application.Features.Branch.Common;
public record WorkingHoursDto(TimeOnly From,TimeOnly To,PersianDayOfWeek DayOfWeek);