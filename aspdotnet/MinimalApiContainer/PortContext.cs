using Microsoft.EntityFrameworkCore;

namespace MinimalApiContainer
{
    public class PortContext:DbContext
    {
        public PortContext(DbContextOptions<PortContext> options) : base(options)
        {

        }
        public DbSet<Port>? Ports { get; set; }
    }
}
