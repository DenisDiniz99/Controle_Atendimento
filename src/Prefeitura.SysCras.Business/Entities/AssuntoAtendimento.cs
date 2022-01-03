using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class AssuntoAtendimento : Entidade
    {
        public string TituloAssunto { get; set; }
        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
