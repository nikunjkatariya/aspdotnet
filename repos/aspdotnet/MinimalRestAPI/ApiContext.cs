namespace MinimalRestAPI
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options):base(options)
        {

        }

        public DbSet<Article> Articles { get; set; } = null!;
    }
}
