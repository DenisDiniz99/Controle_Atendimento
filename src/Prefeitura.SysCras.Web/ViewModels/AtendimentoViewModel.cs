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

        [DisplayName("Data e Hora de Atendimento")]
        public DateTime DataHoraAtendimento { get; set; }

        [DisplayName("Data e Hora de Atualização")]
        public DateTime DataHoraAtualizacao { get; set; }

        [DisplayName("Tipo Atendimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string TipoAtendimento { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Protocolo")]
        public int Protocolo { get; set; }

        [DisplayName("Cidadão")]
        public Guid CidadaoId { get; set; }
        
        [DisplayName("Assunto")]
        public Guid AssuntoId { get; set; }
        
        [DisplayName("Colaborador")]
        public Guid ColaboradorId { get; set; }
        
        [DisplayName("Status")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public StatusAtendimento StatusAtendimento { get; set; }

        [DisplayName("Observação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Observacao { get; set; }
    }
}
