using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.Extensions;
using Prefeitura.SysCras.Web.Utils;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class AtendimentoController : BaseController
    {
        private readonly IAtendimentoRepositorio _repositorio;
        private readonly ICidadaoRepositorio _cidadaoRepositorio;
        private readonly ITipoAtendimentoRepositorio _tipoAtendimentoRepositorio;
        private readonly IAssuntoAtendimentoRepositorio _assuntoAtendimentoRepositorio;
        private readonly IAtendimentoServico _servico;
        private readonly IUser _user;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AtendimentoController(IAtendimentoRepositorio repositorio,
                                        ICidadaoRepositorio cidadaoRepositorio,
                                        ITipoAtendimentoRepositorio tipoAtendimentoRepositorio,
                                        IAssuntoAtendimentoRepositorio assuntoAtendimentoRepositorio,
                                        IAtendimentoServico servico,
                                        IUser user,
                                        UserManager<IdentityUser> userManager,
                                        IMapper mapper,
                                        INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
            _cidadaoRepositorio = cidadaoRepositorio;
            _tipoAtendimentoRepositorio = tipoAtendimentoRepositorio;
            _assuntoAtendimentoRepositorio = assuntoAtendimentoRepositorio;
            _servico = servico;
            _user = user;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AtendimentoViewModel>>(await _repositorio.ObterTodos()));
        }


        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        public async  Task<IActionResult> NovoAtendimento()
        {
            if (!_user.Autenticado())
                return NotFound();

            var tipos = await ObterTiposAtendimento();
            var assuntos = await ObterAssuntos();
            var cidadaos = await ObterCidadaos();

            ViewBag.CidadaoId = new SelectList(cidadaos, "Id", "Nome");
            ViewBag.TipoId = new SelectList(tipos, "Id", "Tipo");
            ViewBag.AssuntoId = new SelectList(assuntos, "Id", "TituloAssunto");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoAtendimento(AtendimentoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);

            model.UsuarioId = Guid.Parse(user.Id.ToString());
            model.DataHoraAtendimento = DateTime.Now;
            model.DataHoraAtualizacao = DateTime.Now;
            model.Protocolo = GeradorProtocolo.NumProtocolo();

            await _servico.Adicionar(_mapper.Map<Atendimento>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach(var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            if(string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index");

            return LocalRedirect("returnUrl");
        }


        public async Task<IActionResult> AtualizarStatus(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarStatus(Guid id, StatusAtendimento statusAtendimento)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            await _servico.AtualizarStatus(id, statusAtendimento);

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach(var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Index");
        }

        //Método privado para pesquisar dados pelo Id
        private async Task<AtendimentoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AtendimentoViewModel>(await _repositorio.ObterPorId(id));
        }

        //Método privado para obter os cidadãos
        private async Task<IEnumerable<CidadaoViewModel>> ObterCidadaos()
        {
            return _mapper.Map<IEnumerable<CidadaoViewModel>>(await _cidadaoRepositorio.ObterTodos());
        }

        //Método privado para obter os tipos de atendimento
        private async Task<IEnumerable<TipoAtendimentoViewModel>> ObterTiposAtendimento()
        {
            return _mapper.Map<IEnumerable<TipoAtendimentoViewModel>>(await _tipoAtendimentoRepositorio.ObterTodos());
        }

        //Método privado para obter os assuntos
        private async Task<IEnumerable<AssuntoAtendimentoViewModel>> ObterAssuntos()
        {
            return _mapper.Map<IEnumerable<AssuntoAtendimentoViewModel>>(await _assuntoAtendimentoRepositorio.ObterTodos());
        }
    }
}