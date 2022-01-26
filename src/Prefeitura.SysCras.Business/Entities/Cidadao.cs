using Prefeitura.SysCras.Business.Enums;
using Prefeitura.SysCras.Business.ValueObjects;
using System;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Entities
{
    public class Cidadao : Entidade
    {
        public string Nome { get; set; }
        public string Nis { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public ESexo Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public string TelefoneFixo { get; set; }
        public string Celular { get; set; }
        public DateTime DataCad { get; set; }
        public bool Situacao { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public IEnumerable<Atendimento> Atendimentos { get; set; }
    }
}
