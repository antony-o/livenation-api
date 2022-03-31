namespace LiveNation.Api.Services;

using Microsoft.Extensions.Caching.Memory;

public class CacheService: ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public T Get<T>(string cacheKey)
    {
        return (T)_memoryCache.Get(cacheKey);
    }

    public void Set(string cacheKey, object cacheItem)
    {
        _memoryCache.Set(cacheKey, cacheItem);
    }
}