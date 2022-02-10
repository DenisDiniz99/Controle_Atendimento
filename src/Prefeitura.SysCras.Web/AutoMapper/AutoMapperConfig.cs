using AutoMapper;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.ValueObjects;
using Prefeitura.SysCras.Web.ViewModels;

namespace Prefeitura.SysCras.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AssuntoAtendimentoViewModel, AssuntoAtendimento>().ReverseMap();
            CreateMap<AtendimentoViewModel, Atendimento>().ReverseMap();
            CreateMap<TipoAtendimentoViewModel, TipoAtendimento>().ReverseMap();
            CreateMap<CidadaoViewModel, Cidadao>().ReverseMap();
            CreateMap<EnderecoViewModel, Endereco>().ReverseMap();
            CreateMap<FiliacaoViewModel, Filiacao>().ReverseMap();
        }
    }
}
