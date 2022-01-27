using System.Collections.Generic;
using System.Security.Claims;

namespace Prefeitura.SysCras.Web.Extensions
{
    public interface IUser
    {
        string NomeUsuario { get; }
        bool Autenticado();
        IEnumerable<Claim> ObterClaimsIndentity();
    }
}
