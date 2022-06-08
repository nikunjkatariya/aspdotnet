using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetBooks()
        {
            return await _context.customers.ToListAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetBook(int id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

/*        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
