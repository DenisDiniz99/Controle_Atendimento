using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class SetorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Setor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string TituloSetor { get; set; }

        public EnderecoViewModel Endereco { get; set; }
        
        public IEnumerable<CargoViewModel> Cargos { get; set; }
    }
}
