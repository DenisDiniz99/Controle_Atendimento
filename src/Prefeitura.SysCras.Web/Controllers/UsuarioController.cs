using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        private readonly IMapper _mapper;


        public UsuarioController(INotificador notificador, 
                                    UserManager<IdentityUser> userManager, 
                                    SignInManager<IdentityUser> signInManager,
                                    IColaboradorRepositorio colaboradorRepositorio,
                                    IMapper mapper) : base(notificador)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _colaboradorRepositorio = colaboradorRepositorio;
            _mapper = mapper;
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

            //Verifica a ModelState
            if (!ModelState.IsValid) return View(model);

            //Verifica se existe um usuário com o nome informado
            var user = await _userManager.FindByNameAsync(model.Nome);
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou Senha inválida!");
                return View(model);
            }

            //Tenta realizar login com o usuário e senha informados
            var result = await _signInManager.PasswordSignInAsync(user, model.Senha, model.LembrarLogin, true);
            //Verifica se existe cadastro de colaborador com o mesmo Id do usuário logado

            //Verifica se houve falha durante o login
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Usuário ou Senha inválida!");
                return View(model);
            }

            //Verifica se o usuário esta bloqueado por tentativas incorretas de acesso
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, $"Usuário {model.Nome} temporariamente bloqueado por tentativas de acesso inválidas");
                return View(model);
            }

            var colaborador = _mapper.Map<ColaboradorViewModel>(await _colaboradorRepositorio.ObterPorId(Guid.Parse(user.Id)));
            //Se não existir colaborador cadastrado, redireciona para o cadastro de colaborador
            if (colaborador == null)
            {
                return RedirectToAction("Perfil", "Colaborador");
            }




            return RedirectToAction("Perfil", "Colaborador");
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
                UserName = model.Nome,
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

            if(string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Cadastrar", "Colaborador");

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        
        
    }
}
