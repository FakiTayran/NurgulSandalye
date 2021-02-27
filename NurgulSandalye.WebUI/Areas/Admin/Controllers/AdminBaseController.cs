using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurgulSandalye.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class AdminBaseController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public AdminBaseController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
    }
}
