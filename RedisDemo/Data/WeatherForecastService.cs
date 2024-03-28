namespace RedisDemo.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly","Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering"
    };

    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
    {
        var rng = new Random();
        await Task.Delay(1500);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
