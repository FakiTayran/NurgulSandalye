using Ardalis.Specification;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Concrete.Spesifications
{
    public class ProductFilterSpesification : Specification<Product>
    {
        public ProductFilterSpesification(int? categoryId,int?subCategoryId,int? materialId,bool? discount,StockStatus? status) : base()
        {
            Query.Where(x =>
            (!categoryId.HasValue || x.CategoryId == categoryId) &&
            (!subCategoryId.HasValue || x.SubCategoryId == categoryId)&& 
            (!materialId.HasValue || x.MaterialId == materialId)&& 
            (!discount.HasValue || x.Discount == discount) &&
            (!status.HasValue || x.StockStatus == status));
        }
    }
}
