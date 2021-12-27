using Prefeitura.SysCras.Business.ValueObjects;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Setor : BaseEntidade
    {
        public string TituloSetor { get; set; }
        public Endereco Endereco { get; set; }

        public IEnumerable<Cargo> Cargos { get; set; }
    }
}
