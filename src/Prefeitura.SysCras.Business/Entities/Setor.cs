using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Setor : Entidade
    {
        public string TituloSetor { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
    }
}