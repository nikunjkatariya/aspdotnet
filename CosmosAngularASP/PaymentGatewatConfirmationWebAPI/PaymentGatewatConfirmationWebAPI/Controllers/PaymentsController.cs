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
        private readonly ICosmosDbService _cosmosDbService;
        private readonly IConfiguration _configuration;
        private dynamic client;
        private ServiceBusReceiver receiver;
        private static ServiceBusReceivedMessage receivedMessage;
        Payment payment;
        public PaymentsController(IConfiguration configuration,ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ?? throw new ArgumentNullException(nameof(cosmosDbService));
            _configuration = configuration;
            client = new ServiceBusClient(_configuration["AzureConnectionString"]);
            receiver = client.CreateReceiver(_configuration["QueueName"]);
        }
        // GET: api/<PaymentsController>
        [HttpGet]   
        public async Task<IActionResult> Get()
        {
            receivedMessage = await receiver.ReceiveMessageAsync();
            string body = receivedMessage.Body.ToString();
            payment = JsonConvert.DeserializeObject<Payment>(body);
            await _cosmosDbService.AddPayment(payment);
            await receiver.CompleteMessageAsync(receivedMessage);
            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
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
