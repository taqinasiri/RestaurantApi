namespace Restaurant.Domain.Common;

public static class AuditableShadowProperties
{
    public const string CreatedByBrowserName = nameof(CreatedByBrowserName);
    public const string ModifiedByBrowserName = nameof(ModifiedByBrowserName);
    public const string CreatedByIp = nameof(CreatedByIp);
    public const string ModifiedByIp = nameof(ModifiedByIp);
    public const string CreatedByUserId = nameof(CreatedByUserId);
    public const string ModifiedByUserId = nameof(ModifiedByUserId);
    public const string CreatedDateTime = nameof(CreatedDateTime);
    public const string ModifiedDateTime = nameof(ModifiedDateTime);
}