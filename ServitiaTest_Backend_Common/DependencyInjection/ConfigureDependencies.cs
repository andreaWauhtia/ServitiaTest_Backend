using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServitiaTest_Backend_Common.Configuration;

namespace ServitiaTest_Backend_Common.DependencyInjection
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigureCommonDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PersistenceConfig>(configuration.GetSection("PersistenceConfig"));

            return services;
        }

    }
}
