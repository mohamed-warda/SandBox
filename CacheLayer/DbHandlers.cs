namespace CacheLayer;

public interface IDbHandlers<T>
{
    Task<T> GetAllAsync();
}


