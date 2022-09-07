using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using TraderSys.Portfolios.Data;
using TraderSys.Portfolios.Models.Context;
using TraderSys.Portfolios.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TraderSys.Portfolios.Repositories
{
    
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IDbContextFactory<Context> context) : base(context) { }
        public async Task<bool> Create(Product product)
        {        
            using (var context = base.Context.CreateDbContext())
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
            return true;
        }
    }
}