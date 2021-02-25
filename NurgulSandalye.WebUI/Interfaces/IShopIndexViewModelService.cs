﻿using Microsoft.AspNetCore.Mvc.Rendering;
using NurgulSandalye.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurgulSandalye.WebUI.Interfaces
{
    public interface IShopIndexViewModelService
    {
        Task<ShopIndexViewModel> GetShopIndexViewModel(int? categoryId, int? subCategoryId, int? materialId);

        Task<List<SelectListItem>> GetCategoryListItem();
        Task<List<SelectListItem>> GetSubCategoryListItem();
        Task<List<SelectListItem>> GetMaterialListItem();

    }
}
