using Microsoft.EntityFrameworkCore;
using InventoryManagementMVCVSix.Models;

namespace InventoryManagementMVCVSix.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Login> Logins { get; set; } = null!;
    }
}
