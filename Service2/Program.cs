using CacheLayer;
using Service2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddCacheLayer();
builder.Services.AddSingleton(typeof(IDbHandlers<List<WeatherForecast>>),typeof(WeatherHandlers));
builder.Services.AddSingleton(typeof(IDbHandlers<List<Person>>),typeof(PersonHandler));
builder.Services.AddSingleton(typeof(CacheImp<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

