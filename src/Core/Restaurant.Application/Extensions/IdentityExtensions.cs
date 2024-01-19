namespace Restaurant.Application.Extensions;

public static class IdentityExtensions
{
    public static List<string> GetErrors(this IdentityResult identityResult)
        => identityResult.Errors.Select(e => e.Description).ToList();
}