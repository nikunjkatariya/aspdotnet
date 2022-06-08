using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentGatewatConfirmationWebAPI.Models;
using PaymentGatewatConfirmationWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGatewatConfirmationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private static ICosmosDbService _cosmosDbService;
        private readonly IConfiguration _configuration;
        static ServiceBusClient client;
        static ServiceBusProcessor processor;
        static Payment payment;
        public PaymentsController(IConfiguration configuration,ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
            _configuration = configuration;
        }
        // GET: api/<PaymentsController>
        [HttpGet]   
        public async Task<IActionResult> Get()
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
            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
        }
        static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            payment = JsonConvert.DeserializeObject<Payment>(body);
            await _cosmosDbService.AddPayment(payment);
            await args.CompleteMessageAsync(args.Message);
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        /*        // GET api/<PaymentsController>/5
                [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }

                // POST api/<PaymentsController>
                [HttpPost]
                public void Post([FromBody] string value)
                {
                }

                // PUT api/<PaymentsController>/5
                [HttpPut("{id}")]
                public void Put(int id, [FromBody] string value)
                {
                }

                // DELETE api/<PaymentsController>/5
                [HttpDelete("{id}")]
                public void Delete(int id)
                {
                }*/
    }
}
