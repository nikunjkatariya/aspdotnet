#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeonDeskWebAPI;

namespace PeonDeskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeonsController : ControllerBase
    {
        private readonly PeonContext _context;

        public PeonsController(PeonContext context)
        {
            _context = context;
        }

        // GET: api/Peons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peon>>> GetPeons()
        {
            return await _context.Peons.ToListAsync();
        }

        // GET: api/Peons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peon>> GetPeon(int id)
        {
            var peon = await _context.Peons.FindAsync(id);

            if (peon == null)
            {
                return NotFound();
            }

            return peon;
        }

        // PUT: api/Peons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeon(int id, Peon peon)
        {
            if (id != peon.Id)
            {
                return BadRequest();
            }

            _context.Entry(peon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeonExists(id))
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

        // POST: api/Peons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Peon>> PostPeon(Peon peon)
        {
            _context.Peons.Add(peon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeon", new { id = peon.Id }, peon);
        }

        // DELETE: api/Peons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeon(int id)
        {
            var peon = await _context.Peons.FindAsync(id);
            if (peon == null)
            {
                return NotFound();
            }

            _context.Peons.Remove(peon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeonExists(int id)
        {
            return _context.Peons.Any(e => e.Id == id);
        }
    }
}
