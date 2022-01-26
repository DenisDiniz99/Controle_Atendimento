using Prefeitura.SysCras.Business.ValueObjects;
using System;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Atendimento : Entidade
    {
        public DateTime DataAtendimento { get; set; }
        public DateTime HoraAtendimento { get; set; }
        public DateTime HoraAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public ETipoAtendimento TipoAtendimento { get; set; }
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
}
