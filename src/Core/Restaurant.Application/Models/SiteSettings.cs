namespace Restaurant.Application.Models;

public class SiteSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = null!;
}

public class ConnectionStrings
{
    public string ApplicationDbContextConnection { get; set; } = null!;
}