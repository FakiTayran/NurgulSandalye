using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NurgulSandalye.Business.Abstract;
using NurgulSandalye.Entities;
using NurgulSandalye.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMaterialService _materialService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IMaterialService materialService,ISubCategoryService subCategoryService,ICategoryService categoryService)
        {
            _productService = productService;
            _materialService = materialService;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {

            var model = new ProductListViewModel()
            {
                Products = await _productService.ListAllProductAsync(),
                Material = await _materialService.ListAllMaterialAsync(),
                SubCategories = await _subCategoryService.ListAllSubCategoryAsync()
            };
            return View(model);
        }
        public async Task<IActionResult> New(NewProductViewModel vm)
        {
            var categories = await _categoryService.ListAllCategoryAsync();
            var subCategories = await _subCategoryService.ListAllSubCategoryAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            ViewBag.subcategories = new SelectList(subCategories, "Id", "Name");
            //var product = new Product()
            //{
            //   Description=vm.Description,
            //   MaterialId= vm.Material.Id,


            //};
            //_productService.AddProduct(product);
            return View();
        }
        public async Task<IActionResult> GetSubCategory(int Id)
        {
            var story = _subCategoryService.ListAllSubCategoryAsync();
            
            if (story == null)
            {
                return NotFound();

            }
            string content = story.Content;
            return Json(new { result = content });
        }
    }
}
