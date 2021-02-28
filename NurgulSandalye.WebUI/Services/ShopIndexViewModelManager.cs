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
        public async Task<ShopIndexViewModel> GetShopIndexViewModel(int? categoryId, int? subCategoryId, int? materialId,bool? discount,int pageId)
        {
            var spec = new ProductFilterPaginatedSpesification(categoryId, subCategoryId, materialId, discount,(pageId-1)*Constants.ITEMS_PER_PAGE,Constants.ITEMS_PER_PAGE);
            var specAll = new ProductFilterSpesification(categoryId, subCategoryId, materialId, discount);
            var products = await _productService.ListProductsAsync(spec);
            var allCount = await _productService.ProductCountAsync(specAll);
            var totalPages = (int)Math.Ceiling(allCount / (double)Constants.ITEMS_PER_PAGE);

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
                Materials = await GetMaterialListItem(),
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                MaterialId = materialId,
                Discount = discount,
                PaginationInfo = new PaginationViewModel()
                { 
                    ItemsOnPage = products.Count(),
                    TotalItems = allCount,
                    TotalPages = totalPages,
                    CurrentPage = pageId,
                    HasPrevious = pageId > 1,
                    HasNext = pageId < totalPages
                }
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
