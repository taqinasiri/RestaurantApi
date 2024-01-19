namespace Restaurant.Persistence.Extensions;

public static class EFExtensions
{
    public static void RegisterAllEntities(this ModelBuilder builder,Type type)
    {
        var entities = type.Assembly.GetTypes().Where(x => x.BaseType == type);
        foreach(var entity in entities)
            builder.Entity(entity);
    }
}