using Restaurant.Domain.Common;

namespace Restaurant.Application.Extensions;

public static class DateTimeExtensions
{
    public static PersianDayOfWeek GetPersianDayOfWeek(this DateTime dateTime)
        => dateTime.DayOfWeek switch
        {
            DayOfWeek.Sunday => PersianDayOfWeek.Sunday,
            DayOfWeek.Monday => PersianDayOfWeek.Monday,
            DayOfWeek.Tuesday => PersianDayOfWeek.Tuesday,
            DayOfWeek.Wednesday => PersianDayOfWeek.Wednesday,
            DayOfWeek.Thursday => PersianDayOfWeek.Thursday,
            DayOfWeek.Friday => PersianDayOfWeek.Friday,
            DayOfWeek.Saturday => PersianDayOfWeek.Saturday,
            _ => throw new InvalidOperationException()
        };

    public static TimeOnly GetTime(this DateTime dateTime) => TimeOnly.FromDateTime(dateTime);

    public static DateOnly GetDate(this DateTime dateTime) => DateOnly.FromDateTime(dateTime);
}