using Microsoft.AspNetCore.Identity;

namespace Restaurant.Application.Models;

public class SiteSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = null!;
    public string UserDefaultAvatar { get; set; } = null!;
    public AdminUserSeed AdminUserSeed { get; set; } = null!;

    public bool EnableEmailConfirmation { get; set; }
    public TimeSpan EmailConfirmationTokenProviderLifespan { get; set; }
    public PasswordOptions PasswordOptions { get; set; } = null!;
    public LockoutOptions LockoutOptions { get; set; } = null!;
    public CookieOptions CookieOptions { get; set; } = null!;
}

public class ConnectionStrings
{
    public string ApplicationDbContextConnection { get; set; } = null!;
}

public class CookieOptions
{
    public string AccessDeniedPath { get; set; }
    public string CookieName { get; set; }
    public TimeSpan ExpireTimeSpan { get; set; }
    public string LoginPath { get; set; }
    public string LogoutPath { get; set; }
    public bool SlidingExpiration { get; set; }
}

public class AdminUserSeed
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}