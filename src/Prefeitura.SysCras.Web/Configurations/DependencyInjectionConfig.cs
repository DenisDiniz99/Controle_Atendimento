using Microsoft.Extensions.DependencyInjection;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Data.Context;
using Prefeitura.SysCras.Data.Repositories;

namespace Prefeitura.SysCras.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Contexto
            services.AddScoped<SysContext>();

            //Repositórios
            services.AddScoped<IAssuntoAtendimentoRepositorio, AssuntoAtendimentoRepositorio>();
            services.AddScoped<IAtendimentoRepositorio, AtendimentoRepositorio>();
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            services.AddScoped<ICidadaoRepositorio, CidadaoRepositorio>();
            services.AddScoped<IColaboradorRepositorio, ColaboradorRepositorio>();
            services.AddScoped<ISetorRepositorio, SetorRepositorio>();

            return services;
        }
    }
}
