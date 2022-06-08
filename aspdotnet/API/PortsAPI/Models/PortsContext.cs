using Microsoft.EntityFrameworkCore;

namespace PortsAPI.Models
{
    public class PortsContext:DbContext
    {
        public PortsContext(DbContextOptions<PortsContext> options) : base(options) 
        {
            
        }
        public DbSet<Ports> Ports { get; set; }
    }
}
