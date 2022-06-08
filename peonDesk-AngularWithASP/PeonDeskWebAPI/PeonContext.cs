using Microsoft.EntityFrameworkCore;

namespace PeonDeskWebAPI
{
    public class PeonContext : DbContext
    {
        public PeonContext(DbContextOptions<PeonContext> options) : base(options)
        {

        }
        public DbSet<Peon> Peons { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
