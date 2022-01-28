using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class CidadaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("NIS")]
        public string Nis { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 11)]
        public string Cpf { get; set; }

        [DisplayName("RG")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string Rg { get; set; }

        [DisplayName("Sexo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sexo { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public DateTime DataNasc { get; set; }

        [DisplayName("Telefone Fixo")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string TelefoneFixo { get; set; }

        [DisplayName("Celular")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string Celular { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCad { get; set; }

        [DisplayName("Situação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Situacao { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
