using CacheLayer;
using Microsoft.AspNetCore.Mvc;

namespace Service2.Controllers;


[ApiController]
[Route("[controller]")]
public class TestController:ControllerBase
{
    private readonly CacheImp<List<WeatherForecast>> _handler;
    public TestController(CacheImp<List<WeatherForecast>> handler)
    {
        _handler = handler;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weather =await _handler.GetOrCreate("weather_forecast");

        return Ok(weather);
    }
}