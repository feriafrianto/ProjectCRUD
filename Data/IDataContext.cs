using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraderSys.Portfolios.Models.Entities;

namespace TraderSys.Portfolios.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}