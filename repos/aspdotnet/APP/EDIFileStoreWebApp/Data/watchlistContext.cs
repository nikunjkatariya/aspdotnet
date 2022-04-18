using Microsoft.EntityFrameworkCore;
using EDIFileStoreWebApp.Models;

namespace EDIFileStoreWebApp.Data
{
    public class watchlistContext : DbContext
    {
        public watchlistContext (DbContextOptions<watchlistContext> options):base(options)
        {
        }
        public DbSet<watchlist> Watchlist { get; set; }
    }
}
