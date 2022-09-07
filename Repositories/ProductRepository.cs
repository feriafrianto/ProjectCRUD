using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraderSys.Portfolios.Data;
using TraderSys.Portfolios.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TraderSys.Portfolios.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Product product)
        {        
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}