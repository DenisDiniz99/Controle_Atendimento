using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Web.Configurations
{
    public static class AppConfig
    {
        public static void AddAppConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SysContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
