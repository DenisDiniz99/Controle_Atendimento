using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class RegistroViewModel
    {
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido")]
        public string Email { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(16, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DisplayName("Confirme sua senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(16, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmeSenha { get; set; }
    }
}