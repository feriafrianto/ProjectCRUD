using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraderSys.Portfolios.Repositories
{
    public static class RepositoryDI
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();

            return services;
        }
    }
}