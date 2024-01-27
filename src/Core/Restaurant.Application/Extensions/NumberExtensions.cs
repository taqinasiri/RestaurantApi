namespace Restaurant.Application.Extensions;

public static class NumberExtensions
{
    public static bool IsNotNullAndNotZero(this long? number)
        => number is not null and not 0;
}