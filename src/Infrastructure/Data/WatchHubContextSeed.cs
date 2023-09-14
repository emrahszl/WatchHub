using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class WatchHubContextSeed
    {
        public static async Task SeedAsync(WatchHubContext db)
        {
            await db.Database.MigrateAsync();

            if (await db.Categories.AnyAsync() || await db.Brands.AnyAsync() || await db.Products.AnyAsync())
                return;

            var category1 = new Category() { CategoryName = "Mens" };
            var category2 = new Category() { CategoryName = "Ladies" };
            var category3 = new Category() { CategoryName = "Unisex" };

            var brand1 = new Brand() { BrandName = "Fossil" };
            var brand2 = new Brand() { BrandName = "Cassio" };
            var brand3 = new Brand() { BrandName = "Tissot" };
            var brand4 = new Brand() { BrandName = "Citizen" };

            List<Product> productList = new List<Product>
            {
                new Product() { Category = category1, Brand = brand1, PictureUri = "01.jpg", ProductPrice = 211.35m, ProductName = "Gents Fossil Blue Watch FS6013" },
                new Product() { Category = category1, Brand = brand1, PictureUri = "02.jpg", ProductPrice = 186.34m, ProductName = "Gents Fossil Watches Incription Watch" },
                new Product() { Category = category1, Brand = brand1, PictureUri = "03.jpg", ProductPrice = 198.85m, ProductName = "Gents Fossil Watches Neutra Watch" },
                new Product() { Category = category2, Brand = brand1, PictureUri = "04.jpg", ProductPrice = 186.34m, ProductName = "Ladies Fossil Raquel Watch ES5303" },
                new Product() { Category = category2, Brand = brand1, PictureUri = "05.jpg", ProductPrice = 248.87m, ProductName = "Ladies Fossil Raquel Watch ES5304" },
                new Product() { Category = category3, Brand = brand1, PictureUri = "06.jpg", ProductPrice = 348.92m, ProductName = "Fossil Gen 6 Ombre Bluetooth 5 Smartwatch FTW4061" },
                new Product() { Category = category1, Brand = brand2, PictureUri = "07.jpg", ProductPrice = 211.35m, ProductName = "Mens Casio Sapphire Crystal 710 Series Chronograph Watch" },
                new Product() { Category = category2, Brand = brand2, PictureUri = "08.jpg", ProductPrice = 137.57m, ProductName = "Casio 'G-Shock' Pink Plastic/Resin Quartz Watch" },
                new Product() { Category = category3, Brand = brand3, PictureUri = "09.jpg", ProductPrice = 1183.01m, ProductName = "Tissot Titanium Solar Powered Bluetooth Smartwatch" },
                new Product() { Category = category2, Brand = brand3, PictureUri = "10.jpg", ProductPrice = 315.09m, ProductName = "Ladies Tissot Classic Dream Small Watch" },
                new Product() { Category = category1, Brand = brand4, PictureUri = "11.jpg", ProductPrice = 373.93m, ProductName = "Mens Citizen Tsuyosa Automatic Watch" },
                new Product() { Category = category2, Brand = brand4, PictureUri = "12.jpg", ProductPrice = 211.35m, ProductName = "Citizen Eco-Drive Crystal Case Ladies Watch Black" }
            };

            db.AddRange(productList);
            await db.SaveChangesAsync();
        }
    }
}
