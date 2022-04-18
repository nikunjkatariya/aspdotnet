using Microsoft.EntityFrameworkCore;
using CustomersWebApp.Models;

namespace CustomersWebApp.Models
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customer> CustomerData { get; set; }
    }
}
