using BlueModas.Data.Repositories;
using BlueModas.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();


            return services;
        }
    }
}
