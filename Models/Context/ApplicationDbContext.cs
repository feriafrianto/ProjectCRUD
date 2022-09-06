using System;
using Microsoft.EntityFrameworkCore;
using TraderSys.Portfolios.Models.Entities;

namespace TraderSys.Portfolios.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

