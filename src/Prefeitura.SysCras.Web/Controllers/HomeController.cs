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

        public IActionResult Privacidade()
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
                    model.Titulo = "Internal Server Error";
                    model.Mensagem = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 404:
                    model.StatusCode = id;
                    model.Titulo = "Not Found";
                    model.Mensagem = "Desculpe, mas a página não pode ser encontrada! Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 403:
                    model.StatusCode = id;
                    model.Titulo = "Forbidden";
                    model.Mensagem = "Desculpe, mas você não tem permissão para acessar este recurso. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                case 400:
                    model.StatusCode = id;
                    model.Titulo = "Bad Request";
                    model.Mensagem = "Desculpe, mas ocorreu um erro durante a requisição. Em caso de dúvidas, entre em contato com o suporte!";
                    break;
                default:
                    model.StatusCode = 500;
                    model.Titulo = "Internal Server Error";
                    model.Mensagem = "Desculpe, mas ocorreu um erro. Tente novamente mais tarde. Em caso de dúvidas entre em contato com o suporte!";
                    break;
            }

            return View("Erro", model);
        }
    }
}
