using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraderSys.Portfolios.Models.Entities;

namespace TraderSys.Portfolios.Repositories
{
    public interface IProductRepository
    {
        public Task<bool> Create(Product product);
    }
}