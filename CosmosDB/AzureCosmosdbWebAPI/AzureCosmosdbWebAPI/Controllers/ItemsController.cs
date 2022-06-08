using AzureCosmosdbWebAPI.Models;
using AzureCosmosdbWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureCosmosdbWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public ItemsController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService ??
                throw new ArgumentNullException(nameof(cosmosDbService));
        }

        // GET: api/items
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _cosmosDbService.GetMultipleAsync("SELECT * FROM c"));
        }

        // GET api/items/2
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _cosmosDbService.GetAsync(id));
        }

        // POST api/item
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsync(item);
            return CreatedAtAction(nameof(Get), new {id= item.Id},item);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _cosmosDbService.AddAsync(item);
            return NoContent();
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
