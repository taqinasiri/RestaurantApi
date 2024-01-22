using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Restaurant.Persistence.Extensions;

public static class EFExtensions
{
    public static void RegisterAllEntities(this ModelBuilder builder,Type type)
    {
        var entities = type.Assembly.GetTypes().Where(x => x.BaseType == type);
        foreach(var entity in entities)
            builder.Entity(entity);
    }

    public static void AddIsDeleteQueryFilter<BaseModel>(this ModelBuilder builder) where BaseModel : EntityBase
    {
        Expression<Func<BaseModel,bool>> filterExpr = bm => !bm.IsDeleted;
        foreach(var mutableEntityType in builder.Model.GetEntityTypes())
        {
            if(mutableEntityType.ClrType.IsAssignableTo(typeof(BaseModel)))
            {
                var parameter = Expression.Parameter(mutableEntityType.ClrType);
                var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(),parameter,filterExpr.Body);
                var lambdaExpression = Expression.Lambda(body,parameter);

                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }
    }
}