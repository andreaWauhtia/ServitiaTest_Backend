using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServitiaTest_Backend_Domain.DependencyInjection
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigureDomainDependencies(this IServiceCollection services, IConfiguration configuration)
        { 
            return services;
        }
    }
}
