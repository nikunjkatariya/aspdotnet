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
using System.Data.SqlClient;
using System.Data;

namespace InvoiceGenerater.Controllers
{
    public class InvoiceProductsController : Controller
    {
        private readonly InvoiceContext _context;
        public InvoiceProductsController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: InvoiceProducts
        public async Task<IActionResult> Index(int id)
        {
            Console.WriteLine(id);
            var invoicevalue = await _context.Invoices.FindAsync(id);
            var invoiceContext = _context.InvoiceProducts.Include(i => i.Product).Where(i=>i.InvoiceId==invoicevalue.InvoiceId);
            return View(await invoiceContext.ToListAsync());
        }

        // GET: InvoiceProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProducts
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }

            return View(invoiceProduct);
        }

        // GET: InvoiceProducts/Create
        public async Task<IActionResult> Create(int id)
        {
            var invoicevalue = await _context.Invoices.FindAsync(id);
            InvoiceProduct invoiceProduct = new InvoiceProduct();
            invoiceProduct.InvoiceId = invoicevalue.InvoiceId;
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            return View(invoiceProduct);
        }

        // POST: InvoiceProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        SqlConnection sqlCon = new SqlConnection(@"Server=EFICYIT-LT12;Database=invoiceGenerationDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        DataTable dt1 = new DataTable();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceId,ProductId,ProductQuantity,Discount,ProductTax")] InvoiceProduct invoiceProduct)
        {
            if (ModelState.IsValid)
            {
/*                _context.Add(invoiceProduct);
                await _context.SaveChangesAsync();*/
                SqlDataAdapter sqlda1 = new SqlDataAdapter($"insert into InvoiceProducts (InvoiceId,ProductId,ProductQuantity,Discount,ProductTax) values ('{invoiceProduct.InvoiceId}',{invoiceProduct.ProductId},{invoiceProduct.ProductQuantity},{invoiceProduct.Discount},{invoiceProduct.ProductTax})", sqlCon);
                sqlda1.Fill(dt1);
                return RedirectToAction("Index", "Invoices");
            }
            else
            {
                return NotFound();
            }
            /*ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", invoiceProduct.ProductId);*/
            /*return RedirectToAction("Index","Invoices");*/
        }

        // GET: InvoiceProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProducts.FindAsync(id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", invoiceProduct.ProductId);
            return View(invoiceProduct);
        }

        // POST: InvoiceProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceId,ProductId,ProductQuantity,Discount,ProductTax")] InvoiceProduct invoiceProduct)
        {
            if (id != invoiceProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceProductExists(invoiceProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction("Index","Invoices");
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", invoiceProduct.ProductId);
            return View(invoiceProduct);
        }

        // GET: InvoiceProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProducts
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }

            return View(invoiceProduct);
        }

        // POST: InvoiceProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceProduct = await _context.InvoiceProducts.FindAsync(id);
            _context.InvoiceProducts.Remove(invoiceProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceProductExists(int id)
        {
            return _context.InvoiceProducts.Any(e => e.Id == id);
        }
    }
}
