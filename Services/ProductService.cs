using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductModel = TraderSys.Portfolios.Models.Entities.Product;

namespace TraderSys.Portfolios.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductService _productRepository;
        public ProductService(IProductService productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Create(ProductModel product)
        {
            return await _productRepository.Create(product);
        }
    }
}