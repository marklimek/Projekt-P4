using Microsoft.EntityFrameworkCore;
using ProjektP4.AppLogic.Models;
using System;
using System.IO;

namespace ProjektP4.AppDatabase.Data
{

    internal class WarehouseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "warehouse.db");
            options.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasDiscriminator<string>("ProductType")
            .HasValue<FoodProduct>("Food")
            .HasValue<NonFoodProduct>("NonFood");
        }
    }
}

