using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prefeitura.SysCras.Web.Configurations;

namespace Prefeitura.SysCras.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettigns.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            //if (hostEnvironment.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //Identity
            services.AddIdentityConfig(Configuration);

            //WebMvc
            services.AddWebMvcConfig();

            //Contexto
            services.AddAppConfig(Configuration);

            //Injeção de Dependência
            services.AddDependencyInjectionConfig();   
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebMvcConfig(env);
        }
    }
}
