using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class ColaboradorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Matrícula")]
        public string Matricula { get; set; }

        [DisplayName("Gênero")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sexo { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [DisplayName("Pasep")]
        public int? Pasep { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCad { get; set; }

        [DisplayName("Cargo")]
        public Guid CargoId { get; set; }

        [DisplayName("Situação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Situacao { get; set; }

        public IEnumerable<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
