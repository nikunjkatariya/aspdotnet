using ApiTestingBySarthak.Models;
using ApiTestingBySarthak.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTestingBySarthak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly IShoppingCartService _service;
        
        public ShoppingItemsController(IShoppingCartService service)
        {
            _service = service;
        }
        
        // GET: api/<ShoppingItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        // GET api/<ShoppingItemsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _service.GetById(id);
            return Ok(item);
        }

        // POST api/<ShoppingItemsController>
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get",new { id=item.Id},item);
        }
        // DELETE api/<ShoppingItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var existing = _service.GetById(id);
            if(existing == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return NoContent();
        }
    }
}
