namespace Restaurant.Application.Constants;

public static class CacheKeys
{
    public const string CategoryTree = nameof(CacheKeys);
    public const string Branch = nameof(Branch);
    public const string Category = nameof(Category);
    public const string Order = nameof(Order);
    public const string Product = nameof(Product);
    public const string Table = nameof(Table);
    public const string User = nameof(User);
}

public static class CacheTimes
{
    public static TimeSpan BranchDetails = new(0,0,1,0);
    public static TimeSpan CategoryDetails = new(1,0,0);
    public static TimeSpan OrderDetails = new(1,0,0);
    public static TimeSpan ProductDetails = new(2,0,0);
    public static TimeSpan TableDetails = new(12,0,0);
    public static TimeSpan UserDetails = new(1,0,0);
}