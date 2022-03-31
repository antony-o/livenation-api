namespace LiveNation.Api.Services;

public interface ICacheService
{
    public T Get<T>(string cacheKey);
    public void Set(string cacheKey, object cacheItem);
}