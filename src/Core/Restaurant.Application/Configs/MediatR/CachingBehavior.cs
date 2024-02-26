using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Restaurant.Application.Configs.MediatR;

public class CachingBehavior<TRequest, TResponse>(IDistributedCache cache,IOptions<CacheSettings> settings) : IPipelineBehavior<TRequest,TResponse> where TRequest : ICacheableMediatrQuery
{
    private readonly IDistributedCache _cache = cache;
    private readonly CacheSettings _settings = settings.Value;

    public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next,CancellationToken cancellationToken)
    {
        TResponse response;

        if(request.BypassCache)
            return await next();

        var cachedResponse = await _cache.GetAsync(request.CacheKey,cancellationToken);
        response = cachedResponse is not null ?
             JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse))! :
             await GetResponseAndAddToCache();

        return response;

        async Task<TResponse> GetResponseAndAddToCache()
        {
            response = await next();
            var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromMinutes(_settings.CacheExpirationMinutes) : request.SlidingExpiration;
            var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
            var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
            await _cache.SetAsync(request.CacheKey,serializedData,options,cancellationToken);
            return response;
        }
    }
}