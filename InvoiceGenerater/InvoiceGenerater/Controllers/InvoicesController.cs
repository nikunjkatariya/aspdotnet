#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerater.Data;
using InvoiceGenerater.Models;
using System.Dynamic;

namespace InvoiceGenerater.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceContext _context;
        private readonly Format _format;

        public InvoicesController(InvoiceContext context,Format format)
        {
            _context = context;
            _format = format;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var invoiceContext = _context.Invoices.Include(i => i.Client);
            return View(await invoiceContext.ToListAsync());
        }

        public async Task<IActionResult> Add(int id)
        {
            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.Id = id;
            return RedirectToAction("Create", "InvoiceProducts", invoiceProduct);
        }
        public async Task<IActionResult> Update(int id)
        {
            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.Id = id;
            return RedirectToAction("Index", "InvoiceProducts", invoiceProduct);
        }
        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            _format.Invoice = invoice;
            /*var invoiceProduct = await _context.InvoiceProducts
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);*/

            /*_format.InvoiceProduct =  invoiceProduct;*/
            var invoicevalue = await _context.Invoices.FindAsync(id);
            var invoiceContext = _context.InvoiceProducts.Include(i => i.Product).Where(i => i.InvoiceId == invoicevalue.InvoiceId);
            /*_format.InvoiceProduct =await invoiceContext.ToListAsync();*/
            return View(_format);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {

            Invoice invoice = new Invoice();
            invoice.InvoiceId = getInvoiceId();
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName");
            /*ViewBag.Invoice=*/
            return View(invoice);
        }

        public string getInvoiceId()
        {
            var InvoiceLength = _context.Invoices.Count()+1;
            var InvoiceId =InvoiceLength.ToString().PadLeft(8, '0');
            InvoiceId = "INV" + InvoiceId;
            return InvoiceId;
        }
        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,ClientId,CreatedDate,LastDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName", invoice.ClientId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName", invoice.ClientId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,ClientId,CreatedDate,LastDate")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "ClientName", invoice.ClientId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
