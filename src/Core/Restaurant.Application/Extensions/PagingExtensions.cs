namespace Restaurant.Application.Extensions;

public static class PagingExtensions
{
    public static Paging ToPaging(this PagingRequest paging,int entitiesCount)
        => new(entitiesCount,paging.Page,paging.Take);
}