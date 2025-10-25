using CacheLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;

namespace FusionCacheExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController:ControllerBase
{
    private readonly CacheImp<List<WeatherForecast>> _handler;
    public WeatherController(CacheImp<List<WeatherForecast>> handler)
    {
        _handler = handler;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weather =await _handler.GetOrCreate("weather_forecast");

        return Ok(weather);
    }
    [HttpGet("set")]
    public async Task<IActionResult> set()
    {
       await _handler.Update("weather_forecast" , new List<WeatherForecast>());

        return Ok();
    }
}

[ApiController]
[Route("[controller]")]
public class PersonController:ControllerBase
{
    private readonly CacheImp<List<Person>> _handler;
    public PersonController(CacheImp<List<Person>> handler)
    {
        _handler = handler;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weather =await _handler.GetOrCreate("persons");

        return Ok(weather);
    }
}