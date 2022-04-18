#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerator.Data;
using InvoiceGenerator.Models;
using InvoiceGenerator.Validation;

namespace InvoiceGenerator.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceContext _context;
        private readonly GSTNumberValidation _validation;

        public InvoicesController(InvoiceContext context,GSTNumberValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invoices.ToListAsync());
        }
/*        public async Task<IActionResult> Add(int id)
        {
            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.Id = id;
            return RedirectToAction("Create", "InvoiceProducts", invoiceProduct);
        }*/
        public async Task<IActionResult> Update(int id)
        {
            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.Id = id;
            return RedirectToAction("Indexvalue", "InvoiceProducts", invoiceProduct);
        }
        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoices.FindAsync(id);
            var invoiceProduct = _context.InvoiceProducts.Where(x => x.InvoiceId == invoice.InvoiceId);
            ViewBag.Invoice = invoice;
            ViewBag.InvoiceProduct = invoiceProduct;
            return View();
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceId = getInvoiceId();
            return View(invoice);
        }
        public string getInvoiceId()
        {
            var InvoiceLength = _context.Invoices.Count() + 1;
            var InvoiceId = InvoiceLength.ToString().PadLeft(8, '0');
            InvoiceId = "INV" + InvoiceId;
            return InvoiceId;
        }
        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,ClientName,ClientGST,Address,City,PinCode,PANNumber,ContactNumber,CreatedDate,LastDate")] Invoice invoice)
        {
            if(_validation.IsValid(invoice.ClientGST, invoice.PANNumber))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(invoice);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
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
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,ClientName,ClientGST,Address,City,PinCode,PANNumber,ContactNumber,CreatedDate,LastDate")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }
            if (_validation.IsValid(invoice.ClientGST, invoice.PANNumber))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        invoice.CreatedDate = DateTime.Now;
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
            }
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
