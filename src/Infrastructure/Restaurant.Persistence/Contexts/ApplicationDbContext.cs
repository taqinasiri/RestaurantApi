﻿namespace Restaurant.Persistence.Contexts;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User,Role,long,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.RegisterAllEntities(typeof(EntityBase));
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.AddAuditableShadowProperties();
        builder.AddIsDeleteQueryFilter<EntityBase>();
    }
}