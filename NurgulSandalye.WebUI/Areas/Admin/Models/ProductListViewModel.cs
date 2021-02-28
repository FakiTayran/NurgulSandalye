using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public List<Material> Material { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
