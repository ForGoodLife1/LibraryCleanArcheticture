using Library.Infrustructure.Abstracts;
using Library.Infrustructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();


            return services;
        }
    }
}