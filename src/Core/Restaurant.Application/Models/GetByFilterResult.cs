namespace Restaurant.Application.Models;

public class GetByFilterResult<TData> where TData : class
{
    public List<TData>? Data { get; set; }
    public int ResultsCount { get; set; }
}