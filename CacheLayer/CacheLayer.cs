using Microsoft.Extensions.Caching.Hybrid;
using ZiggyCreatures.Caching.Fusion;

namespace CacheLayer;

public class CacheImp<T>
{
    private readonly HybridCache _cache;
    private readonly IDbHandlers<T> handler;
    private readonly IFusionCache _fusionCache;

    public CacheImp(HybridCache cache, IDbHandlers<T> handler, IFusionCache fusionCache)
    {
        _cache = cache;
        this.handler = handler;
        _fusionCache = fusionCache;
    }

    public async Task<T> GetOrCreate(string key)
    {
        var result =await _cache.GetOrCreateAsync(key, 
            async _=> await handler.GetAllAsync()
        );
        return result;
    }
    public async Task Update(string key, T value)
    {
        await _cache.SetAsync(key, value);
    }
}