// Ignore Spelling: Auditable

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Restaurant.Persistence.Interceptors;

internal class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _contextAccessor;

    public AuditableEntityInterceptor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,InterceptionResult<int> result)
    {
        UpdateAuditableEntities(eventData.Context);

        return base.SavingChanges(eventData,result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,InterceptionResult<int> result,CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);

        return base.SavingChangesAsync(eventData,result,cancellationToken);
    }

    public void UpdateAuditableEntities(DbContext? context)
    {
        if(context == null)
            return;

        DateTime utcNow = DateTime.UtcNow;

        foreach(var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            if(entry.State == EntityState.Added)
            {
                SetCurrentPropertyValue(entry,AuditableShadowProperties.CreatedByUserId,_contextAccessor.HttpContext?.User.GetUserId());
                SetCurrentPropertyValue(entry,AuditableShadowProperties.CreatedDateTime,utcNow);
                SetCurrentPropertyValue(entry,AuditableShadowProperties.CreatedByIp,_contextAccessor.HttpContext?.GetIP());
                SetCurrentPropertyValue(entry,AuditableShadowProperties.CreatedByBrowserName,_contextAccessor.HttpContext?.GetUserAgent());
            }
            else if(entry.State == EntityState.Modified)
            {
                SetCurrentPropertyValue(entry,AuditableShadowProperties.ModifiedByUserId,_contextAccessor.HttpContext?.User.GetUserId());
                SetCurrentPropertyValue(entry,AuditableShadowProperties.ModifiedDateTime,utcNow);
                SetCurrentPropertyValue(entry,AuditableShadowProperties.ModifiedByIp,_contextAccessor.HttpContext?.GetIP());
                SetCurrentPropertyValue(entry,AuditableShadowProperties.ModifiedByBrowserName,_contextAccessor.HttpContext?.GetUserAgent());
            }
        }

        static void SetCurrentPropertyValue(EntityEntry entry,string propertyName,object? value)
            => entry.Property(propertyName).CurrentValue = value;
    }
}