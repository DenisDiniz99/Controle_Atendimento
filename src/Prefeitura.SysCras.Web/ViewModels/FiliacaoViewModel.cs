using System.ComponentModel.DataAnnotations;

namespace Prefeitura.SysCras.Web.ViewModels
{
    public class FiliacaoViewModel
    {
        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres")]
        public string NomePai { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter até {1} caracteres")]
        public string NomeMae { get; set; }
    }
}
