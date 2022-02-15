using Prefeitura.SysCras.Business.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class AtendimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DataHoraAtendimento { get; set; }

        public DateTime DataHoraAtualizacao { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Descricao { get; set; }

        [Required]
        public int Protocolo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int StatusAtendimento { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Observacao { get; set; }

        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo Cidadão é obrigatório.")]
        public Guid CidadaoId { get; set; }
        
        [Required(ErrorMessage = "O campo Assunto é obrigatório.")]
        public Guid AssuntoAtendimentoId { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Atendimento é obrigatório.")]
        public Guid TipoAtendimentoId { get; set; }

        public CidadaoViewModel Cidadao { get; set; }
        public AssuntoAtendimentoViewModel AssuntoAtendimento { get; set; }
        public TipoAtendimentoViewModel TipoAtendimento { get; set; }
    }
}
