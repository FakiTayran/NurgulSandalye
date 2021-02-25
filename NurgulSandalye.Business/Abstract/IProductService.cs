﻿using NurgulSandalye.DataAccess.Abstract;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Abstract
{
    public interface IProductService 
    {
        Task<List<Product>> ListPopularProductAsync();
        Task<List<Product>> ListAllProductAsync();

    }
}
