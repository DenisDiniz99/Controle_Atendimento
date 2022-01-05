using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O campo {0} não está em um formato válido.")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(6, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
