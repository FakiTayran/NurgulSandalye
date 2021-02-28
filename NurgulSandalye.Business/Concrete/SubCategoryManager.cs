using Ardalis.Specification;
using NurgulSandalye.Business.Abstract;
using NurgulSandalye.DataAccess.Abstract;
using NurgulSandalye.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgulSandalye.Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repository;

        public SubCategoryManager(ISubCategoryRepository repository)
        {
            _repository = repository;
        }
        public Task<List<SubCategory>> ListAllSubCategoryAsync()
        {
            return _repository.ListAllAsync();
        }

        public async Task<List<SubCategory>> ListSubCategoryAsync(ISpecification<SubCategory> spec)
        {
            return await _repository.ListAsync(spec);
        }
    }
}
