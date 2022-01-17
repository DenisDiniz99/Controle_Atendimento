using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(6, ErrorMessage = "O campo {0} deve conter {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DisplayName("Lembrar-me")]
        public bool LembrarLogin { get; set; }
    }
}
