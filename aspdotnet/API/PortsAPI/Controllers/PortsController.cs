using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortsAPI.Models;

namespace PortsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortsController : ControllerBase
    {
        private readonly PortsContext _context;

        public PortsController(PortsContext context)
        {
            _context = context;
        }

        // GET: api/Ports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ports>>> GetPorts()
        {
            return await _context.Ports.ToListAsync();
        }

        // GET: api/Ports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ports>> GetPorts(int id)
        {
            var ports = await _context.Ports.FindAsync(id);

            if (ports == null)
            {
                return NotFound();
            }

            return ports;
        }

        // PUT: api/Ports/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPorts(int id, Ports ports)
        {
            if (id != ports.Id)
            {
                return BadRequest();
            }

            _context.Entry(ports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortsExists(id))
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

        // POST: api/Ports
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ports>> PostPorts(Ports ports)
        {
            _context.Ports.Add(ports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPorts", new { id = ports.Id }, ports);
        }

        // DELETE: api/Ports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ports>> DeletePorts(int id)
        {
            var ports = await _context.Ports.FindAsync(id);
            if (ports == null)
            {
                return NotFound();
            }

            _context.Ports.Remove(ports);
            await _context.SaveChangesAsync();

            return ports;
        }

        private bool PortsExists(int id)
        {
            return _context.Ports.Any(e => e.Id == id);
        }
    }
}
