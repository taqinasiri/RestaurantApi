using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities.Identity;

public class User : IdentityUser<long>, IAuditableEntity
{
}