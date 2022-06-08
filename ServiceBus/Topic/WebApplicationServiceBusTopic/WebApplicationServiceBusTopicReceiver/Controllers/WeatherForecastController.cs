using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationServiceBusTopicReceiver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        static ServiceBusClient client;
        static ServiceBusProcessor processor;
        static string message;
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

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            client = new ServiceBusClient(_configuration["AzureConnectionString"]);
            processor = client.CreateProcessor(_configuration["TopicName"], _configuration["subscriptionName"], new ServiceBusProcessorOptions());
            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync();

                /*Console.WriteLine("Waiting...");
                Console.ReadKey();*/
                Thread.Sleep(6000);

                //Stop
                Console.WriteLine("Stopping the Reception!");
                await processor.StopProcessingAsync();
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
            return message;
        }
        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"{body}");
            message += body +", ";
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}