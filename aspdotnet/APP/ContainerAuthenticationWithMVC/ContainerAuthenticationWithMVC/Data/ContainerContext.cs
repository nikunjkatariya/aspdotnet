using Microsoft.EntityFrameworkCore;
using ContainerAuthenticationWithMVC.Models;

namespace ContainerAuthenticationWithMVC.Data
{
    public class ContainerContext : DbContext
    {
        public ContainerContext(DbContextOptions<ContainerContext> options) : base(options)
        {

        }
        public DbSet<Container>? Containers { get; set; }
        
        public static User[] users = new User[]{
            new User{Username="Mosh",Password="123",UserType="User",Token=""},
            new User{Username="Josh",Password="324",UserType="Admin",Token=""},
        };
        public static IEnumerable<User> GetUsers()
        {
            return users;
        }
    }
}
