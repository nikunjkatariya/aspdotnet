using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIFileStoreWebApp.Data;
using EDIFileStoreWebApp.Models;
using System.IO;

namespace EDIFileStoreWebApp.Controllers
{
    public class watchlistsController : Controller
    {
        private readonly watchlistContext _context;

        public watchlistsController(watchlistContext context)
        {
            _context = context;
        }

        // GET: watchlists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Watchlist.ToListAsync());
        }

        // GET: watchlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchlist = await _context.Watchlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchlist == null)
            {
                return NotFound();
            }

            return View(watchlist);
        }

        // GET: watchlists/Create
        public async Task<IActionResult> Create([Bind("Id,ISA,GS,ST,B4,SE,GE,IEA")] watchlist watchlist)
        {
            string ediX12path = @"D:\testedi.txt";
            StreamReader sr = new StreamReader(ediX12path);
            string data = sr.ReadToEnd();
            sr.Close();
            string[] value = data.Split('*');

            string sender = value[0];
            for (int v = 0; v < value.Length; v++)
            {
                if (value[v].Contains("ISA"))
                    watchlist.ISA = String.Join(Environment.NewLine, value[v + 5]);
                if (value[v].Contains("GS"))
                    watchlist.GS = String.Join(Environment.NewLine, value[v + 1]);
                if (value[v].Contains("ST"))
                    watchlist.ST = String.Join(Environment.NewLine, value[v + 1]);
                if (value[v].Contains("B4"))
                    watchlist.B4 = String.Join(Environment.NewLine, value[v + 1]);
                if (value[v].Contains("SE"))
                    watchlist.SE = String.Join(Environment.NewLine, value[v + 1]);
                if (value[v].Contains("GS"))
                    watchlist.GE = String.Join(Environment.NewLine, value[v + 2]);
                if (value[v].Contains("IEA"))
                    watchlist.IEA = String.Join(Environment.NewLine, value[v + 2]);
            }
            if (ModelState.IsValid)
            {
                _context.Add(watchlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watchlist);
        }

        // POST: watchlists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create1([Bind("Id,ISA,GS,ST,B4,SE,GE,IEA")] watchlist watchlist)
        {
            return View(watchlist);
        }

        // GET: watchlists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchlist = await _context.Watchlist.FindAsync(id);
            if (watchlist == null)
            {
                return NotFound();
            }
            return View(watchlist);
        }

        // POST: watchlists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISA,GS,ST,B4,SE,GE,IEA")] watchlist watchlist)
        {
            if (id != watchlist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!watchlistExists(watchlist.Id))
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
            return View(watchlist);
        }

        // GET: watchlists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var watchlist = await _context.Watchlist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchlist == null)
            {
                return NotFound();
            }

            return View(watchlist);
        }

        // POST: watchlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var watchlist = await _context.Watchlist.FindAsync(id);
            _context.Watchlist.Remove(watchlist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool watchlistExists(int id)
        {
            return _context.Watchlist.Any(e => e.Id == id);
        }
    }
}
