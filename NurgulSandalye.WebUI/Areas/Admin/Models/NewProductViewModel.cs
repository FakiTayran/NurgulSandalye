using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Areas.Admin.Models
{
    public class NewProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public StockStatus StockStatus { get; set; }

        public Material Material { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
        public decimal Price { get; set; }

        public bool Discount { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public SubCategory SubCategory { get; set; }

        public ICollection<PictureUri> PictureUris { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
