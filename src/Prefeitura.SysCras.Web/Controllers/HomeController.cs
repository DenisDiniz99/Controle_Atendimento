using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Web.ViewModels;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(INotificador notificador) : base(notificador) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Erro(int id)
        {
            var model = new ErroViewModel();

            switch (id)
            {
                case 500:
                    model.StatusCode = id;
                    model.Titulo = "Ops! Ocorreu um erro!";
                    model.Mensagem = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 404:
                    model.StatusCode = id;
                    model.Titulo = "Ops! Página não encontrada!";
                    model.Mensagem = "Desculpe, mas a página não pode ser encontrada! Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 403:
                    model.StatusCode = id;
                    model.Titulo = "Ops! Acesso negado!";
                    model.Mensagem = "Desculpe, mas você não tem permissão para acessar este recurso. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                default:
                    model.StatusCode = 500;
                    model.Titulo = "Ops! Ocorreu um erro!";
                    model.Mensagem = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas entre em contato com o suporte!";
                    break;
            }

            return View("Erro", model);
        }
    }
}
