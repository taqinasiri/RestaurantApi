﻿using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities.Identity;

public class Role : IdentityRole<long>, IAuditableEntity
{
}