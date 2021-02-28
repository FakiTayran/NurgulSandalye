using Microsoft.AspNetCore.Mvc.Rendering;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.ViewModels
{
    public class ShopIndexViewModel
    {
        public List<ProductViewModel> Products { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }

        public List<SelectListItem> Materials { get; set; }

        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? MaterialId { get; set; }

        public bool? Discount { get; set; }
        public PaginationViewModel PaginationInfo { get; set; }


    }
}
