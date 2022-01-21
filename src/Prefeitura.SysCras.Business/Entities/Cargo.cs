using System;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Cargo : Entidade
    {
        public string TituloCargo { get; set; }
        public Guid SetorId { get; set; }
        public Setor Setor { get; set; }

        public IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}