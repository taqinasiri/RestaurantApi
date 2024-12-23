﻿using Restaurant.Application.Features.Branch.Common;

namespace Restaurant.Application.Features.Branch.Requests.Queries;

public class GetBranchDetailsQuery(int id) : IRequest<GetBranchDetailsResponse>, ICacheableMediatrQuery
{
    public int Id { get; set; } = id;

    public bool BypassCache { get; set; }
    public TimeSpan? SlidingExpiration => CacheTimes.BranchDetails;
    public string CacheKey => $"{CacheKeys.Branch}-{Id}";
}

public record class GetBranchDetailsResponse(long Id,string Title,string? Description,string Slug,string Address)
{
    public List<string>? Images { get; set; }
    public List<WorkingHoursDto>? WorkingHoursDtos { get; set; }
}