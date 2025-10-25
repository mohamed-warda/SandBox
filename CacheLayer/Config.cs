using System.Reflection;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane.StackExchangeRedis;

namespace CacheLayer;

public static class Config
{
    public static IServiceCollection AddCacheLayer(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddFusionCache().WithSystemTextJsonSerializer()
            .WithDistributedCache(new RedisCache(
                new RedisCacheOptions()
                {
                    Configuration ="localhost:6379"
                })).WithBackplane(new RedisBackplane(new RedisBackplaneOptions { Configuration = "localhost:6379" }))
            .WithDefaultEntryOptions(op =>
            {
                op.SetDurationInfinite();
            }).AsHybridCache();
        services.AddSingleton(typeof(CacheImp<>));
        foreach (var assembly in assemblies)
        {
            var handlerTypes = assembly.GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract)
                .Select(t => new
                {
                    Type = t,
                    Interface = t.GetInterfaces()
                        .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDbHandlers<>))
                })
                .Where(x => x.Interface != null).ToList();

            foreach (var handler in handlerTypes)
            {
                services.AddSingleton(handler.Interface, handler.Type);
            }
        }
        
        
        
        
        
        return services;
    }
    
}