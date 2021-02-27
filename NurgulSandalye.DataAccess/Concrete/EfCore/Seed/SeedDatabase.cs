using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.DataAccess.Concrete.EfCore.Seed
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            NurgulSandalyeContext context = new NurgulSandalyeContext();

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { Name = "Sandalye"});
                context.SaveChanges();
                context.Categories.Add(new Category() { Name = "Bar Sandalyesi"});
                context.SaveChanges();
                context.Categories.Add(new Category() { Name = "Masa"});
                context.SaveChanges();
                context.Categories.Add(new Category() { Name = "Bar Masası" });
                context.SaveChanges();
                context.Categories.Add(new Category() { Name = "Bahçe Mobilyası"});
                context.SaveChanges();
                context.Categories.Add(new Category() { Name = "Aksesuarlar"});
                context.SaveChanges();
            }

            if (!context.SubCategories.Any())
            {
                context.SubCategories.Add(new SubCategory() { Name = "Plastik Sandalye", CategoryId = 1 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ahşap Sandalye", CategoryId = 1 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Metal Sandalye", CategoryId = 1 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Giydirme Sandalye", CategoryId = 1 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ahşap Bar Sandalyesi", CategoryId = 2 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Giydirme Bar Sandalyesi", CategoryId = 2 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Metal Bar Sandalyesi", CategoryId = 2 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ahşap Masa", CategoryId = 3 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Giydirme Masa", CategoryId = 3 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Metal Masa", CategoryId = 3 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ahşap Bar Masası", CategoryId = 4 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Cam Bar Masası", CategoryId = 4 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ratta Bahçe Mobilyaları", CategoryId = 5 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Ahşap Bahçe Mobilyaları", CategoryId = 5 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Aliminyum Bahçe Mobilyaları", CategoryId = 5 });
                context.SaveChanges();
                context.SubCategories.Add(new SubCategory() { Name = "Metal Bahçe Mobilyaları", CategoryId = 5 });
                context.SaveChanges();
            }
            if (!context.Materials.Any())
            {
                context.Materials.Add(new Material() { Name = "Plastik" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "Ahşap" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "Aliminyum" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "Sunta" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "MDF" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "Ceviz Ağazı" });
                context.SaveChanges();
                context.Materials.Add(new Material() { Name = "Meşe Ağazı" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product() {Name = "Lotus Sandalye",SubCategoryId = 2,Price=480m,MaterialId=2,CategoryId=1,StockStatus = StockStatus.InStock});
                context.Products.Add(new Product() {Name = "Lhastic Sandalye",SubCategoryId = 1,Price=200m,MaterialId=1, CategoryId = 1, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Venüs Sandalye",SubCategoryId = 3,Price = 580m, MaterialId=2, CategoryId = 1, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Ehamanza Sandalye",SubCategoryId = 4,Price = 680m,Discount=true,DiscountedPrice=500m, MaterialId = 3, CategoryId = 1, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Kuki Sandalye",SubCategoryId = 5,Price = 450m, MaterialId = 4,CategoryId=2, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Basel Sandalye",SubCategoryId = 6,Price = 350m, Discount = true, DiscountedPrice = 250m, MaterialId = 5, CategoryId = 2, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Auro Masa",SubCategoryId = 6,Price = 290m, MaterialId = 6, CategoryId = 3, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Marble Masa", SubCategoryId = 8,Price = 900m, Discount = true, DiscountedPrice = 700m, MaterialId = 3,CategoryId=3, StockStatus = StockStatus.InStock });
                context.Products.Add(new Product() {Name = "Mecen Masa", SubCategoryId = 11,Price = 1200m,  MaterialId = 2,CategoryId=4, StockStatus = StockStatus.OneWeek });
                context.Products.Add(new Product() {Name = "Burgu Masa", SubCategoryId = 12,Price = 1500m,  MaterialId = 3,CategoryId=4, StockStatus = StockStatus.TwoWeek });
                context.SaveChanges();
            }
            
        }
    }
}
