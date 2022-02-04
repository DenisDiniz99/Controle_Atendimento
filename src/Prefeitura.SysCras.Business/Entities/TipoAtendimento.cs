using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class TipoAtendimento : Entidade
    {
        public string Tipo { get; set; }
        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
