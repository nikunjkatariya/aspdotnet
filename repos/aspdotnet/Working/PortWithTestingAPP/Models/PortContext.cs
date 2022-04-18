using Microsoft.EntityFrameworkCore;

namespace PortWithTestingAPP.Models
{
    public class PortContext:DbContext
    {
        public PortContext(DbContextOptions<PortContext> options) : base(options)
        {

        }

/*        public override void OnModalCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Port>()
                .HasData(new Port
                {
                    Id = 1,
                    PortName = "US",
                    PortId = Guid.NewGuid()
                },new Port
                {
                    Id = 2,
                    PortName = "UK",
                    PortId = Guid.NewGuid()
                },new Port
                {
                    Id = 3,
                    PortName = "Canada",
                    PortId = Guid.NewGuid()
                });
        }*/
        public DbSet<Port>? Ports { get; set; }
    }
}
