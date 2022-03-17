using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public  class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-HH46EBS\SQLEXPRESS;Database = ReCapProject;Trusted_Connection=true") ;
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(b => b.Brand)
                .WithMany(c => c.Cars)
                .HasForeignKey(f => f.BrandId);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Color)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.ColorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
//"Server=(localdb)\MSSQLLocalDB;Database=
//Server = DESKTOP-HH46EBS\SQLEXPRESS