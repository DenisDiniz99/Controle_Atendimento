using Prefeitura.SysCras.Business.ValueObjects;
using System;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Atendimento : Entidade
    {
        public DateTime DataHoraAtendimento { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
        public string Descricao { get; set; }
        public int Protocolo { get; set; }
        public StatusAtendimento StatusAtendimento { get; set; }
        public string Observacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoAtendimentoId { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public Guid CidadaoId { get; set; }
        public Cidadao Cidadao { get; set; }
        public Guid AssuntoAtendimentoId { get; set; }
        public AssuntoAtendimento AssuntoAtendimento { get; set; }
    }
}
