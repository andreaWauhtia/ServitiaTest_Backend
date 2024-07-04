using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServitiaTest_Backend_Persistence.DependencyInjection;
using System.Reflection;

namespace ServitiaTest_Backend_Common.DependencyInjection
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
