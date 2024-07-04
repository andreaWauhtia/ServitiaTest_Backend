using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServitiaTest_Backend_Domain.DependencyInjection;

namespace ServitiaTest_Backend_Persistence.DependencyInjection
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigurePersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddSingleton<ServitiaTestContext, ServitiaTestContext>();
            return services;
        }
    }
}
