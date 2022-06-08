using InvoiceGenerater.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenerater.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options): base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
    }
}
