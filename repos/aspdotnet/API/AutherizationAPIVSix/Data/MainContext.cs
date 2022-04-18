using AutherizationAPIVSix.Models;
using Microsoft.EntityFrameworkCore;

namespace AutherizationAPIVSix.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
