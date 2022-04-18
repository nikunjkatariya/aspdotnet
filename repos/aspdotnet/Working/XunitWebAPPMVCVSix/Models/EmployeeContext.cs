using Microsoft.EntityFrameworkCore;

namespace XunitWebAPPMVCVSix.Models
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData
                (new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Mosh",
                    AccountNumber = "445-66225588551-12",
                    Age = 35
                }, new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Josh",
                    AccountNumber = "445-66225588552-12",
                    Age = 21
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "James",
                    AccountNumber = "445-66225588553-12",
                    Age = 26
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    AccountNumber = "445-66225588554-12",
                    Age = 31
                }
                );
        }
        public DbSet<Employee>? Employee { get; set; }
    }
}
