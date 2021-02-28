using Ardalis.Specification;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Concrete.Spesifications
{
    public class SubCategorySpesification :Specification<SubCategory>
    {
        public SubCategorySpesification(int? CategoryId) : base()
        {
            Query.Where(x => !CategoryId.HasValue || x.CategoryId == CategoryId);
        }
    }
}
