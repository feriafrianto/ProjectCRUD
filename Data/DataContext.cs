using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using TraderSys.Portfolios.Models.Entities;

namespace TraderSys.Portfolios.Data
{
    public class DataContext : DbContext
    {
    public DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=productsDb;Username=admin;Password=admin1234");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);            
    }
    }
}