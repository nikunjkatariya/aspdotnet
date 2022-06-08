using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Azure.ServiceBus;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SendQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrdersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody]Order order)
        {
            QueueClient queueClient = new QueueClient(_configuration["QueueConnectionString"],_configuration["QueueName"]);
            var orderJson = JsonConvert.SerializeObject(order);
            var orderMessage = new Message(Encoding.UTF8.GetBytes(orderJson))
            {
                MessageId=Guid.NewGuid().ToString(),
                ContentType="application/json"
            };
            await queueClient.SendAsync(orderMessage).ConfigureAwait(false);
            return Ok("Creating Order Request has been Successful!");
        }
    }
}
