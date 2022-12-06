using Microsoft.EntityFrameworkCore;
using MiniProjectWeek49;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace MiniProjectWeek49
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb; Database=assets1; Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity<Mobile>().HasData(new Mobile { Id = 1, Brand = "iPhone", Model = "8", Price = 970 });
            ModelBuilder.Entity<Mobile>().HasData(new Mobile { Id = 2, Brand = "iPhone", Model = "11", Price = 990 });
            ModelBuilder.Entity<Mobile>().HasData(new Mobile { Id = 3, Brand = "iphone", Model = "X", Price = 1245 });
            ModelBuilder.Entity<Mobile>().HasData(new Mobile { Id = 4, Brand = "Motorola", Model = "Razr", Price = 970 });

            ModelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 5, Brand = "HP", Model = "Elitebook", TargetArea="Home", Price = 1423 });
            ModelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 6, Brand = "HP", Model = "Elitebook 2", Price = 970 });
            ModelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 7, Brand = "Asus", Model = "W234", Price = 1200 });
            ModelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 8, Brand = "Lenova", Model = "Yoga 730", Price = 835 });
            ModelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 9, Brand = "Lenova", Model = "Yoga 530", Price = 1030 });

            ModelBuilder.Entity<Office>().HasData(new Office { Id = 1, Name = "Spain", Currency = "EUR", Rate = 0.82645 });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 2, Name = "USA", Currency = "USD", Rate = 1.0 });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 3, Name = "Sweden", Currency = "SEK", Rate = 8.334 });

            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 1, ItemId = 1, OfficeId = 1, PurchaseDate = Convert.ToDateTime("12-29-2018") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 2, ItemId = 2, OfficeId = 1, PurchaseDate = Convert.ToDateTime("6-1-2019") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 3, ItemId = 3, OfficeId = 1, PurchaseDate = Convert.ToDateTime("9-25-2020") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 4, ItemId = 4, OfficeId = 2, PurchaseDate = Convert.ToDateTime("7-15-2018") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 5, ItemId = 5, OfficeId = 2, PurchaseDate = Convert.ToDateTime("10-2-2020") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 6, ItemId = 6, OfficeId = 2, PurchaseDate = Convert.ToDateTime("10-2-2020") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 7, ItemId = 7, OfficeId = 3, PurchaseDate = Convert.ToDateTime("4-21-2017") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 8, ItemId = 8, OfficeId = 3, PurchaseDate = Convert.ToDateTime("5-28-2018") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 9, ItemId = 9, OfficeId = 3, PurchaseDate = Convert.ToDateTime("5-21-2019") });
            ModelBuilder.Entity<Asset>().HasData(new Asset { Id = 10, ItemId = 9, OfficeId = 1, PurchaseDate = Convert.ToDateTime("2-21-2020") });
        }
    }
}

