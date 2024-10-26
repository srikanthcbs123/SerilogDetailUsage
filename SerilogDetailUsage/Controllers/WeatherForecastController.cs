using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace SerilogDetailUsage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast[]? data = null;
            try
            {
                var username = "sachintendulkar";//you must read this from token in realtime;
                Log.Information("Weatherforcast controller.Get method Excuction started by:"+ username);
                data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
                throw new Exception();//raise the exception explicit way.
                Log.Information("Weatherforcast controller.Get method Excuction completed by:"+ username);
            }
            catch (Exception ex)
            {
                Log.Error("Custom Failure: {@RequestName}, {@Error}, {@DateTimeUtc}",
                "GetWeatherForecast Method"+"sachin", ex, DateTime.Today);
            }
            return data;
        }
    }
}
