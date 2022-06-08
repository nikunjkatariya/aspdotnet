using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Inspection> Inspections { get; set; }

        public DbSet<InspectionType> inspectionTypes { get; set; }

        public DbSet<Status> statuses { get; set; }
    }
}
