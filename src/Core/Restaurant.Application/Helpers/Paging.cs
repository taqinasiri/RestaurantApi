namespace Restaurant.Application.Helpers;

public class Paging
{
    public Paging(int entitiesCount,int page = 1,int take = 10)
    {
        EntitiesCount = entitiesCount;
        ResultsCount = entitiesCount;
        Page = page;
        Take = take;
    }

    private int _page;
    private int _take;
    private int _entitiesCount;

    public int ResultsCount { get; set; }
    public int Skip => (Page - 1) * Take;
    public int PagesCount => (int)Math.Ceiling(ResultsCount / (double)Take);

    public int EntitiesCount
    {
        get => _entitiesCount;
        set => _entitiesCount = value;
    }

    public int Take
    {
        get => _take;
        set => _take = value < 50 ? value : 50;
    }

    public int Page
    {
        get => _page > PagesCount ? PagesCount : _page;
        set => _page = value;
    }

    #region implicit operators

    public static implicit operator PagingResponse(Paging paging)
        => new(paging.PagesCount,paging.EntitiesCount);

    public static implicit operator PagingQuery(Paging paging)
        => new(paging.Skip,paging.Take);

    #endregion implicit operators
}