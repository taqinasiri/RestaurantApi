using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities;

public class User : IdentityUser<long>, IAuditableEntity
{
}