using System;
using Microsoft.EntityFrameworkCore;
using TraderSys.Portfolios.Models.Entities;

namespace TraderSys.Portfolios.Models.Context
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("Host=localhost;Port=5432;Database=productsDb;Username=admin;Password=admin1234");
            }
        }
    }
}

