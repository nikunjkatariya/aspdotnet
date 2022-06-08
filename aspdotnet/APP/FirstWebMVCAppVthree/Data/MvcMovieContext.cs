using Microsoft.EntityFrameworkCore;
using FirstWebMVCAppVthree.Models;

namespace FirstWebMVCAppVthree.Data
{
    public class MvcMovieContext:DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options):base(options)
        { }
        public DbSet<Movies> Movies { get; set; }
    }
}
