using Microsoft.EntityFrameworkCore;

namespace CutomerWebAPI.Models
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {}

        public DbSet<CustomerDetails> CustomerData { get; set; }
    }
}
