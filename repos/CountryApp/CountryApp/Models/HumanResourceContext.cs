using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CountryApp.Models
{
    public partial class HumanResourceContext : DbContext
    {
        public HumanResourceContext()
        {
        }

        public HumanResourceContext(DbContextOptions<HumanResourceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Capital).HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(50);

                entity.Property(e => e.Economy).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
