using Microsoft.AspNetCore.Mvc;
using paymentGatewayWebAPI.CosmosServices;
using paymentGatewayWebAPI.Models;
using Microsoft.Azure.Cosmos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace paymentGatewayWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public PaymentsController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService??throw new ArgumentNullException(nameof(cosmosDbService));
        }
        // GET: api/payments
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cosmosDbService.GetPayments("SELECT * FROM c"));
        }

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/payments
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Payment payment)
        {
            var data = await _cosmosDbService.GetPayments("SELECT * FROM c");
            var length = data.Count();
            payment.Id = (length+1).ToString();
            payment.TransactionId = "#T2RT4AASRD" + (length+1).ToString();
            await _cosmosDbService.AddPayment(payment);
            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
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
        }
    }
}
