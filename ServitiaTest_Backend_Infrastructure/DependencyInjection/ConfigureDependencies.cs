using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServitiaTest_Backend_Common.DependencyInjection
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigureInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        { 
            return services;
        }
    }
}
