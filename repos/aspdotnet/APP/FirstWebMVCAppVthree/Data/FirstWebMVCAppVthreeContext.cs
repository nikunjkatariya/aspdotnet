using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstWebMVCAppVthree.Models;

namespace FirstWebMVCAppVthree.Data
{
    public class FirstWebMVCAppVthreeContext : DbContext
    {
        public FirstWebMVCAppVthreeContext (DbContextOptions<FirstWebMVCAppVthreeContext> options)
            : base(options)
        {
        }

        public DbSet<FirstWebMVCAppVthree.Models.Movies> Movies { get; set; }
    }
}
