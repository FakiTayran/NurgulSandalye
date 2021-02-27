using System;
using System.Collections.Generic;
using System.Text;

namespace NurgulSandalye.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public StockStatus StockStatus { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public decimal Price { get; set; }

        public bool Discount { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PictureUri> PictureUris { get; set; }
    }

    public enum StockStatus
    { 
        InStock = 0,
        OneWeek = 1,
        TwoWeek = 2,
    }
}
