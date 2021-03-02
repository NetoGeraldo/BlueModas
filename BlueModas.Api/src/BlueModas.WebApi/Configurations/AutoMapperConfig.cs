using BlueModas.WebApi.Automapper;
using Microsoft.Extensions.DependencyInjection;

namespace BlueModas.WebApi.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));

            return services;
        }
    }
}
