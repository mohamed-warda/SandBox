using CacheLayer;
using FusionCacheExample;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
/*
builder.Services.AddFusionCache().WithSystemTextJsonSerializer()
    .WithDistributedCache(new RedisCache(
        new RedisCacheOptions()
    {
        Configuration = builder.Configuration.GetConnectionString("RedisConnectionString") 
    }))
    .WithDefaultEntryOptions(op =>
    {
        op.SetDurationInfinite();
    }).AsHybridCache();
    */

builder.Services.AddCacheLayer(typeof(WeatherHandlers).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();


