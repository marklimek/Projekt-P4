using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.IO;

namespace Data
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
