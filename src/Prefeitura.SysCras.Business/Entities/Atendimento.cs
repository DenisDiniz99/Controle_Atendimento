using Prefeitura.SysCras.Business.ValueObjects;
using System;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Atendimento : BaseEntidade
    {
        public DateTime DataAtend => DateTime.Now.Date;
        public DateTime HoraAtend => DateTime.Now.ToLocalTime();
        public TipoAtendimento TipoAtendimento { get; set; }
        public string Descricao { get; set; }
        public Protocolo Protocolo { get; set; }
        public Guid CidadaoId { get; set; }
        public Cidadao Cidadao { get; set; }
        public Guid AssuntoId { get; set; }
        public AssuntoAtendimento AssuntoAtendimento { get; set; }
        public Guid ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public string Observacao { get; set; }
    }

    public enum TipoAtendimento
    {
        PBF,
        Piscicologa,
        Assistencia,
        Direcao,
        Avaliacao
    }

    public enum StatusAtendimento
    {
        Aberto,
        Cancelado,
        Finalizado,
        Parado,
        Analise 
    }
}
