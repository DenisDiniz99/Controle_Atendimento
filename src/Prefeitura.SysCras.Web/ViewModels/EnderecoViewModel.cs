using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class EnderecoViewModel
    {
        [DisplayName("Rua")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Rua { get; set; }

        [DisplayName("Número")]
        [MaxLength(10, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Numero { get; set; }

        [DisplayName("Bairro")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        public string Cidade { get; set; }

        [DisplayName("CEP")]
        [StringLength(8, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 8)]
        public string Cep { get; set; }

        [DisplayName("Estado")]
        [StringLength(2, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 2)]
        public string Estado { get; set; }
    }
}
