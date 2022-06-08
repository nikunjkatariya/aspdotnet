using Microsoft.EntityFrameworkCore;
using InventoryManagementAPIVSix.Models;

namespace InventoryManagementAPIVSix
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
