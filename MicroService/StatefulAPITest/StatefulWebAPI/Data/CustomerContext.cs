using Microsoft.EntityFrameworkCore;
using StatefulWebAPI.Models;

namespace StatefulWebAPI.Data
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> customerdetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=EFICYIT-LT12;Database=customerdetails;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
