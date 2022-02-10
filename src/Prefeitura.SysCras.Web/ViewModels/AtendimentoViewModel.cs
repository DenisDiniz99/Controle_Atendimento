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
        [StringLength(2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Descricao { get; set; }

        public int Protocolo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public StatusAtendimento StatusAtendimento { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Observacao { get; set; }

        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo Cidadão é obrigatório.")]
        public Guid CidadaoId { get; set; }
        
        [Required(ErrorMessage = "O campo Assunto é obrigatório.")]
        public Guid AssuntoId { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Atendimento é obrigatório.")]
        public Guid TipoAtendimentoId { get; set; }

        public CidadaoViewModel Cidadao { get; set; }
        public AssuntoAtendimentoViewModel AssuntoAtendimento { get; set; }
        public TipoAtendimentoViewModel TipoAtendimento { get; set; }
    }
}
