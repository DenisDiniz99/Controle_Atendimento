using AutoMapper;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.ViewModels;

namespace Prefeitura.SysCras.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AssuntoAtendimentoViewModel, AssuntoAtendimento>().ReverseMap();
            CreateMap<AtendimentoViewModel, Atendimento>().ReverseMap();
            CreateMap<CargoViewModel, Cargo>().ReverseMap();
            CreateMap<CidadaoViewModel, Cidadao>().ReverseMap();
            CreateMap<ColaboradorViewModel, Colaborador>().ReverseMap();
            CreateMap<SetorViewModel, Setor>().ReverseMap();
        }
    }
}
