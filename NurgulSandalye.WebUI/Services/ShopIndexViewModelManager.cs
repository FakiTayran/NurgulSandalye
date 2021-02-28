using Microsoft.AspNetCore.Mvc.Rendering;
using NurgulSandalye.Business.Abstract;
using NurgulSandalye.Business.Concrete.Spesifications;
using NurgulSandalye.Entities;
using NurgulSandalye.WebUI.Interfaces;
using NurgulSandalye.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Services
{
    public class ShopIndexViewModelManager : IShopIndexViewModelService
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMaterialService _materialService;

        public ShopIndexViewModelManager(IProductService productService,ICategoryService categoryService,ISubCategoryService subCategoryService,IMaterialService materialService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _materialService = materialService;
        }
        public async Task<ShopIndexViewModel> GetShopIndexViewModel(int? categoryId, int? subCategoryId, int? materialId,bool? discount)
        {
            var spec = new ProductFilterSpesification(categoryId, subCategoryId, materialId, discount);
            var products = await _productService.ListProductsAsync(spec);

            return new ShopIndexViewModel()
            {
                Products = products.Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    //PictureUris = x.PictureUris.ToList(),
                    Description = x.Description,
                    Discount = x.Discount,
                    DiscountedPrice = x.DiscountedPrice,
                    Material = x.Material,
                }).ToList(),
                Categories = await GetCategoryListItem(),
                SubCategories = await GetSubCategoryListItem(categoryId),
                Materials = await GetMaterialListItem()
            };
        }

        public async Task<List<SelectListItem>> GetCategoryListItem()
        {
            return (await _categoryService.ListAllCategoryAsync()).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        public async Task<List<SelectListItem>> GetMaterialListItem()
        {
            return (await _materialService.ListAllMaterialAsync()).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }


        public async Task<List<SelectListItem>> GetSubCategoryListItem(int? categoryId)
        {
            var spec = new SubCategorySpesification(categoryId);
            return (await _subCategoryService.ListSubCategoryAsync(spec)).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
    }
}
