using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        private string[] Names = new[]
        {
        "Mosh", "Joseph", "Choksi", "Jun", "Jasmin", "Bosh", "Jek", "Alex"
    };
        private string[] Addresses = new[]
        {
        "Mosh", "Joseph", "Choksi", "Jun", "Jasmin", "Bosh", "Jek", "Alex"
    };
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Name = Names[Random.Shared.Next(Names.Length)],
                Address = Addresses[Random.Shared.Next(Addresses.Length)],
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}