// Ignore Spelling: Auditable

namespace Restaurant.Persistence.Extensions;

public static class AuditableShadowPropertiesExtensions
{
    public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
    {
        foreach(var entityType in modelBuilder.Model
            .GetEntityTypes()
            .Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                .Property<string>(AuditableShadowProperties.CreatedByBrowserName).HasMaxLength(1000);
            modelBuilder.Entity(entityType.ClrType)
                .Property<string>(AuditableShadowProperties.ModifiedByBrowserName).HasMaxLength(1000);

            modelBuilder.Entity(entityType.ClrType)
                .Property<string>(AuditableShadowProperties.CreatedByIp).HasMaxLength(255);
            modelBuilder.Entity(entityType.ClrType)
                .Property<string>(AuditableShadowProperties.ModifiedByIp).HasMaxLength(255);

            modelBuilder.Entity(entityType.ClrType)
                .Property<long?>(AuditableShadowProperties.CreatedByUserId);
            modelBuilder.Entity(entityType.ClrType)
                .Property<long?>(AuditableShadowProperties.ModifiedByUserId);

            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTime>(AuditableShadowProperties.CreatedDateTime);
            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTime?>(AuditableShadowProperties.ModifiedDateTime);
        }
    }
}