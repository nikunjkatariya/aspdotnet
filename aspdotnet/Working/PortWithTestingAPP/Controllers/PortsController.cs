#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortWithTestingAPP.Models;
using PortWithTestingAPP.Validation;

namespace PortWithTestingAPP.Controllers
{
    public class PortsController : Controller
    {
        private readonly PortContext _context;
        private readonly PortIdValidation _validation;
        public PortsController(PortContext context, PortIdValidation validation)
        {
            _context = context;
            _validation = validation;
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

            var port = await _context.Ports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // GET: Ports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PortName,PortId")] Port port)
        {
            if (ModelState.IsValid)
            {
                var portsData = _context.Ports.ToList();
                int portlength=portsData.Count;
                if (Ok(portlength,port.PortId))
                {
                    _context.Add(port);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    BadRequest();
                }
            }
            return View(port);
        }

        public bool Ok(int length,int id)
        {
            if(length == id)
                return true;
            return false;
        }

        // GET: Ports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }
            return View(port);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PortName,PortId")] Port port)
        {
            if (id != port.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(port);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortExists(port.Id))
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
            return View(port);
        }

        // GET: Ports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (port == null)
            {
                return NotFound();
            }

            return View(port);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var port = await _context.Ports.FindAsync(id);
            _context.Ports.Remove(port);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortExists(int id)
        {
            return _context.Ports.Any(e => e.Id == id);
        }
    }
}
