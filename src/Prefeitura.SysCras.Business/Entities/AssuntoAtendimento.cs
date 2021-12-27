using System;
using System.Collections.Generic;
using System.Text;

namespace Prefeitura.SysCras.Business.Entities
{
    public class AssuntoAtendimento : BaseEntidade
    {
        public string TituloAssunto { get; set; }
        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
