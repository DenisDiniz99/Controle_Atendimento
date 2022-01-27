using Prefeitura.SysCras.Business.Enums;
using System;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Colaborador : Entidade
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public ESexo Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public int? Pasep { get; set; }
        public DateTime DataCad { get; set; }
        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public bool Situacao { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}