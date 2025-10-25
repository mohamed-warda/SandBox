namespace Service2;


public static class Database
{
    public static List<WeatherForecast> GetWeather()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToList();
    }
    public static List<Person> GetPeople()
    {
        var names = new[]
        {
            "Mohamed", "Sara", "Omar", "Laila", "Hassan",
            "Nadia", "Tamer", "Rania", "Youssef", "Dina"
        };

        var cities = new[]
        {
            "Cairo", "Alexandria", "Giza", "Mansoura", "Luxor"
        };

        return Enumerable.Range(1, 10)
            .Select(i => new Person
            {
                Id = i,
                Name = names[Random.Shared.Next(names.Length)],
                Age = Random.Shared.Next(18, 60),
                City = cities[Random.Shared.Next(cities.Length)]
            })
            .ToList();
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public string City { get; set; } = default!;
}
public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }

}