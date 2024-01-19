namespace Restaurant.Application.Helpers;

public static class StringHelper
{
    public static string GenerateGuid()
        => Guid.NewGuid().ToString("N");
}