using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class CidadaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NomeSocial { get; set; }

        public string Nis { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 8)]
        public string Rg { get; set; }

        public int? TituloEleitor { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Nacionalidade { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Naturalidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int EstadoCivil { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Raca { get; set; }

        public int? NumFilhos { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public DateTime DataNasc { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string TelefoneFixo { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string Celular { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCad { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Situacao { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string Email { get; set; }

        public FiliacaoViewModel Filiacao { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
