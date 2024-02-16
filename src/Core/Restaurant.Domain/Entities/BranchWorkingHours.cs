namespace Restaurant.Domain.Entities;

[Table("BranchWorkingHours")]
public class BranchWorkingHours : EntityBase
{
    public long BranchId { get; set; }
    public TimeOnly From { get; set; }
    public TimeOnly To { get; set; }
    public PersianDayOfWeek DayOfWeek { get; set; }

    #region Relations

    public Branch Branch { get; set; } = null!;

    #endregion Relations
}