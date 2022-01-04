using Microsoft.Extensions.DependencyInjection;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Contexto
            services.AddScoped<SysContext>();

            return services;
        }
    }
}
