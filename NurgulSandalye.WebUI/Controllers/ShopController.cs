using Microsoft.AspNetCore.Mvc;
using NurgulSandalye.Entities;
using NurgulSandalye.WebUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopIndexViewModelService _shopIndexViewModelService;

        public ShopController(IShopIndexViewModelService shopIndexViewModelService)
        {
            _shopIndexViewModelService = shopIndexViewModelService;
        }
        public async Task<IActionResult> Index(int? categoryId, int? subCategoryId, int? materialId, bool? discount,int pageId = 1)
        {
            ViewBag.SelectedCategory = categoryId.ToString();
            ViewBag.SelectedSubCategory = subCategoryId.ToString();
            ViewBag.SelectedMaterial = materialId.ToString();
            ViewBag.SelectedDiscount = discount.ToString();
            return View(await _shopIndexViewModelService.GetShopIndexViewModel(categoryId,subCategoryId,materialId,discount,pageId));
        }

        public IActionResult OrderAdress()
        {
            return View();
        }
        public IActionResult OrderPayment()
        {
            return View();
        }
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
