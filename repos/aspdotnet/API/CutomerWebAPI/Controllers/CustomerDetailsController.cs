using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CutomerWebAPI;
using CutomerWebAPI.Models;

namespace CutomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerDetailsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerData()
        {
            return await _context.CustomerData.ToListAsync();
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(long id)
        {
            var customerDetails = await _context.CustomerData.FindAsync(id);

            if (customerDetails == null)
            {
                return NotFound();
            }

            return customerDetails;
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetails(long id, CustomerDetails customerDetails)
        {
            if (id != customerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            _context.CustomerData.Add(customerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerDetails), new { id = customerDetails.Id }, customerDetails);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDetails>> DeleteCustomerDetails(long id)
        {
            var customerDetails = await _context.CustomerData.FindAsync(id);
            if (customerDetails == null)
            {
                return NotFound();
            }

            _context.CustomerData.Remove(customerDetails);
            await _context.SaveChangesAsync();

            return customerDetails;
        }

        private bool CustomerDetailsExists(long id)
        {
            return _context.CustomerData.Any(e => e.Id == id);
        }
    }
}
