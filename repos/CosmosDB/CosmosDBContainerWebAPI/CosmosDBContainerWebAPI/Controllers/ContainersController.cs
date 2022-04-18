using CosmosDBContainerWebAPI.Models;
using CosmosDBContainerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmosDBContainerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public ContainersController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService??throw new ArgumentNullException(nameof(cosmosDbService));
        }

        // GET: api/Containers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cosmosDbService.GetMultipleAsync("Select * from c"));
        }

        // GET api/<ContainersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _cosmosDbService.GetAsync(id));
        }

        // POST api/<ContainersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContainerData containerData)
        {
/*            containerData.Id = Guid.NewGuid().ToString();*/
            await _cosmosDbService.AddAsync(containerData);
            return CreatedAtAction(nameof(Get), new { id = containerData.Id }, containerData);
        }

        // PUT api/<ContainersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ContainerData containerData)
        {
            await _cosmosDbService.UpdateAsync(containerData.Id,containerData);
            return CreatedAtAction(nameof(Get), new { id = containerData.Id }, containerData);
        }

        // DELETE api/<ContainersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cosmosDbService.DeleteAsync(id);
            return NoContent();
        }
    }
}
