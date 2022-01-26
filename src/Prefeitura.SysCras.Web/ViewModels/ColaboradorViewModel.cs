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
        [StringLength(2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Matricula { get; set; }

        [DisplayName("Gênero")]
        public string Sexo { get; set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

        [DisplayName("Pasep")]
        public string Pasep { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCad { get; set; }

        [DisplayName("Cargo")]
        public Guid CargoId { get; set; }

        public CargoViewModel Cargo { get; set; }

        [DisplayName("Situação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool Situacao { get; set; }

        public IEnumerable<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
