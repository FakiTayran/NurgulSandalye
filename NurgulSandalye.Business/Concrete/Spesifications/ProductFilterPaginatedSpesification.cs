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
        public ProductFilterPaginatedSpesification(int? categoryId, int? subCategoryId, int? materialId, bool? discount,int sortValue,int skip,int take) : base()
        {
            Query.Where(x =>
            (!categoryId.HasValue || x.CategoryId == categoryId) &&
            (!subCategoryId.HasValue || x.SubCategoryId == categoryId) &&
            (!materialId.HasValue || x.MaterialId == materialId) &&
            (!discount.HasValue || x.Discount == discount)).Skip(skip).Take(take);

            switch (sortValue)
            {
                case 1:
                    Query.OrderBy(x => x.Id);
                    break;
                case 2:
                    Query.OrderByDescending(x => x.Id);  // en çok siparişe göre ??
                    break;
                case 3:
                    Query.OrderByDescending(x => x.Price);
                    break;
                case 4:
                    Query.OrderBy(x => x.Price);
                    break;
            }

        }
    }
}
