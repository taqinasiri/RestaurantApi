namespace Restaurant.Application.Constants;

public static class RegularExpressions
{
    public const string Slug = @"^[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$";

    public const string Base64 = @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
}