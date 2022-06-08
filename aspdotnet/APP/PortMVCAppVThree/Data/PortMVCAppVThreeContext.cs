using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortMVCAppVThree.Models;

namespace PortMVCAppVThree.Data
{
    public class PortMVCAppVThreeContext : DbContext
    {
        public PortMVCAppVThreeContext (DbContextOptions<PortMVCAppVThreeContext> options)
            : base(options)
        {
        }

        public DbSet<PortMVCAppVThree.Models.Ports> Ports { get; set; }
    }
}
