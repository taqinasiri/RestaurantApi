using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities;

public class Role : IdentityRole<long>, IAuditableEntity
{
}