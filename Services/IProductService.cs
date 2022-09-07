using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductModel = TraderSys.Portfolios.Models.Entities.Product;

namespace TraderSys.Portfolios.Services
{
    public interface IProductService
    {
        public Task<bool> Create(ProductModel product);
    }
}