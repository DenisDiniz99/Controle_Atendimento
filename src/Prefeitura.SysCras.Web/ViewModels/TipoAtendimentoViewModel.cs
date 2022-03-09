using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class TipoAtendimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Tipo { get; set; }

        public IEnumerable<AtendimentoViewModel> Atendimentos { get; set; }
    }
}
