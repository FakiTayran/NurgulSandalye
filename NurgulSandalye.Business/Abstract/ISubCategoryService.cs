using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Abstract
{
    public interface ISubCategoryService 
    {
        Task<List<SubCategory>> ListAllSubCategoryAsync();
        Task<SubCategory> GetByIdSubCategoryAsync(int id);
    }
}
