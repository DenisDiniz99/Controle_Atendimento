using System;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Colaborador : Entidade
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataCad { get; set; }
        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public bool Status { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
