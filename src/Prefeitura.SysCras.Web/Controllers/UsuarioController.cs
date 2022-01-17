using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Web.ViewModels;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public UsuarioController(INotificador notificador, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : base(notificador)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            //Verifica se existe um usuário com e-mail informado
            var user = await _userManager.FindByEmailAsync(model.Email);
            //Tenta realizar login com o usuário e senha informados
            var result = await _signInManager.PasswordSignInAsync(user, model.Senha, model.LembrarLogin, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou Senha inválida!");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (!result.Succeeded)
            {
                foreach(var erro in result.Errors)
                {
                    AdicionarErros(erro.Description);
                }

                return View(model);
            }

            await _signInManager.PasswordSignInAsync(user, model.Senha, true, false);

            if(string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            return LocalRedirect(returnUrl);
        }
    }
}
