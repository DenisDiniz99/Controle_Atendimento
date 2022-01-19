using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;

namespace Prefeitura.SysCras.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return _notificador.TemNotificacao();
        }

        protected void AdicionarErros(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }
    }
}
