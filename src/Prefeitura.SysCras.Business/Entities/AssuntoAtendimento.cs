using System;
using System.Collections.Generic;
using System.Text;

namespace Prefeitura.SysCras.Business.Entities
{
    public class AssuntoAtendimento : Entidade
    {
        public string TituloAssunto { get; set; }
        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
