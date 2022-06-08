using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebApp.Data
{
    public class AppdbContext:IdentityDbContext<IdentityUser>
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {

        }
    }
}
