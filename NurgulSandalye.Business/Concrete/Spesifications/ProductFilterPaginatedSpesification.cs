using Ardalis.Specification;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Concrete.Spesifications
{
    public class ProductFilterPaginatedSpesification : Specification<Product>
    {
        public ProductFilterPaginatedSpesification(int? categoryId, int? subCategoryId, int? materialId, bool? discount,int skip,int take) : base()
        {
            Query.Where(x =>
            (!categoryId.HasValue || x.CategoryId == categoryId) &&
            (!subCategoryId.HasValue || x.SubCategoryId == categoryId) &&
            (!materialId.HasValue || x.MaterialId == materialId) &&
            (!discount.HasValue || x.Discount == discount)).Skip(skip).Take(take);

        }
    }
}
