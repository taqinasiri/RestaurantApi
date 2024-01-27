namespace Restaurant.Application.Models;

public record PagingRequest(int Page = 1,int Take = 10);

public record PagingResponse(int PagesCount,int EntitiesCount);

public record PagingQuery(int Skip,int Take);