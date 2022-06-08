using LoggerUsinsADO.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerUsinsADO.Data
{
    public class LoginContext: DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {

        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
