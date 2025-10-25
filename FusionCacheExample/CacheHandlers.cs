using CacheLayer;

namespace FusionCacheExample;

public class WeatherHandlers:IDbHandlers<List<WeatherForecast> >
{
    
    public Task<List<WeatherForecast>> GetAllAsync()
    {
        return Task.FromResult( Database.GetWeather());
    }
}
public class PersonHandler:IDbHandlers<List<Person>>
{
    
    public Task<List<Person>> GetAllAsync()
    {
        return Task.FromResult( Database.GetPeople());
    }
}