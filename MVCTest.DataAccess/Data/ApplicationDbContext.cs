﻿using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name = "茶飲",DisplayOrder = 1},
                new Category { Id = 2, Name = "水果茶", DisplayOrder = 2 },
                new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "台灣水果茶",
                    Size = "大杯",
                    Description = "天然果飲，迷人多變。",
                    Price = 60,
                },
                new Product
                {
                    Id = 2,
                    Name = "鐵觀音",
                    Size = "中杯",
                    Description = " 品鐵觀音，享人生的味道。",
                    Price = 35,
                },
                new Product
                {
                    Id = 3,
                    Name = "冰美式咖啡",
                    Size = "中杯",
                    Description = "用咖啡體悟悠閒時光。",
                    Price = 50,
                }
               );
        }
    }
}
