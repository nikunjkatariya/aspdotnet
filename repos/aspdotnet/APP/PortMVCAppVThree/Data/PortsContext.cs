using Microsoft.EntityFrameworkCore;

namespace PortMVCAppVThree.Data
{
    public class PortsContext : DbContext
    {
        public PortsContext(DbContextOptions<PortsContext> options) : base(options) { }
        DbSet<PortsContext> Ports { get; set; }
    }
}
