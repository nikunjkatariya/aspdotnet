using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationServiceBusTopic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        static ServiceBusClient client;
        static ServiceBusSender sender;
        private const int NumofMessages = 3;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpGet(Name = "PassingMessage")]
        public async Task<string> PassMessage()
        {
            client = new ServiceBusClient(_configuration["AzureConnectionString"]);
            sender = client.CreateSender(_configuration["TopicName"]);

            //Creating Batch => Message is passing in Batch
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            var temp=0;
            for (int i = 0; i < NumofMessages; i++)
            {
                temp = Random.Shared.Next(-20, 55);
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Temperature is {temp}")))
                {
                    throw new Exception($"The message {i} is too large");
                }
            }

            try
            {
                await sender.SendMessagesAsync(messageBatch);
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
            return temp.ToString();
        }
    }
}