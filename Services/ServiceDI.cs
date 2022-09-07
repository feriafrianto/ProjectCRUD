using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraderSys.Portfolios.Services
{
    public static class ServiceDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            return services;
        }
    }
}