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
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task  AddProduct(Product product)
        {
            await _repository.AddAsync(product);
        }

        public async Task<int> ProductCountAsync(ISpecification<Product> spec)
        {
            return await _repository.CountAsync(spec);
        }

        public async Task<List<Product>> ListAllProductAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<List<Product>> ListPopularProductAsync()
        {
            return await _repository.ListAllAsync();
        }

        public async Task<List<Product>> ListProductsAsync(ISpecification<Product> spec)
        {
            return await _repository.ListAsync(spec);
        }
    }
}
