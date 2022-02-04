using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Prefeitura.SysCras.Web.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        

        //Obter o nome do usuário logado
        public string NomeUsuario => _httpContextAccessor.HttpContext.User.Identity.Name;


        //Validar se o usuário está autenticado
        public bool Autenticado()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        //Obter todas as claims do usuário
        public IEnumerable<Claim> ObterClaimsIndentity()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }
    }
}
