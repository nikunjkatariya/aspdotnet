using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortMVCAppVThree.Data;
using PortMVCAppVThree.Models;

namespace PortMVCAppVThree.Controllers
{
    public class PortsController : Controller
    {
        private readonly PortMVCAppVThreeContext _context;

        public PortsController(PortMVCAppVThreeContext context)
        {
            _context = context;
        }

        // GET: Ports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ports.ToListAsync());
        }

        // GET: Ports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ports = await _context.Ports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ports == null)
            {
                return NotFound();
            }

            return View(ports);
        }

        // GET: Ports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PortId,Name,Country")] Ports ports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ports);
        }

        // GET: Ports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ports = await _context.Ports.FindAsync(id);
            if (ports == null)
            {
                return NotFound();
            }
            return View(ports);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PortId,Name,Country")] Ports ports)
        {
            if (id != ports.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortsExists(ports.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ports);
        }

        // GET: Ports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ports = await _context.Ports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ports == null)
            {
                return NotFound();
            }

            return View(ports);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ports = await _context.Ports.FindAsync(id);
            _context.Ports.Remove(ports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortsExists(int id)
        {
            return _context.Ports.Any(e => e.Id == id);
        }
    }
}
