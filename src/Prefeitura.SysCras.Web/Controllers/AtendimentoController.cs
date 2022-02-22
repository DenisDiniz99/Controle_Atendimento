using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            if (!_user.Autenticado()) return NotFound();

            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            if (user.Id != model.UsuarioId.ToString()) return BadRequest();

            var assunto = await ObterAssuntoAtendimentoCadastrado(model.AssuntoAtendimentoId);
            var atendimento = await ObterTipoAtendimentoCadastrado(model.TipoAtendimentoId);
            var cidadao = await ObterCidadaoCadastrado(model.CidadaoId);
            var statusAtendimento = "";

            if (model.StatusAtendimento == 1)
                statusAtendimento = "Aberto";
            if (model.StatusAtendimento == 2)
                statusAtendimento = "Cancelado";
            if (model.StatusAtendimento == 3)
                statusAtendimento = "Finalizado";

            

            ViewData["usuario"] = user.UserName;
            ViewData["assunto"] = assunto.TituloAssunto;
            ViewData["atendimento"] = atendimento.Tipo;
            ViewData["cidadao"] = cidadao.Nome;
            ViewData["status"] = statusAtendimento;


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
            model.DataHoraAtendimento = DateTime.UtcNow;
            model.DataHoraAtualizacao = DateTime.UtcNow;
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


        public async Task<IActionResult> Atualizar(Guid id)
        {
            if (!_user.Autenticado()) return NotFound();

            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            if (user.Id != model.UsuarioId.ToString()) return BadRequest();

            var assunto = await ObterAssuntoAtendimentoCadastrado(model.AssuntoAtendimentoId);
            var atendimento = await ObterTipoAtendimentoCadastrado(model.TipoAtendimentoId);
            var cidadao = await ObterCidadaoCadastrado(model.CidadaoId);

            ViewData["usuario"] = user.UserName;
            ViewData["assunto"] = assunto.TituloAssunto;
            ViewData["atendimento"] = atendimento.Tipo;
            ViewData["cidadao"] = cidadao.Nome;

            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, AtendimentoViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            model.DataHoraAtualizacao = DateTime.Now;

            await _servico.Atualizar(_mapper.Map<Atendimento>(model));

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

        //Método privado para obter tipo de atendimento cadastrado em um atendimento
        private async Task<TipoAtendimentoViewModel> ObterTipoAtendimentoCadastrado(Guid id)
        {
            return _mapper.Map<TipoAtendimentoViewModel>(await _tipoAtendimentoRepositorio.ObterPorId(id));
        }

        //Método privado para obter assunto cadastrado em um atendimento
        private async Task<AssuntoAtendimentoViewModel> ObterAssuntoAtendimentoCadastrado(Guid id)
        {
            return _mapper.Map<AssuntoAtendimentoViewModel>(await _assuntoAtendimentoRepositorio.ObterPorId(id));
        }

        //Método privado para obter cidadão cadastrado em um atendimento
        private async Task<CidadaoViewModel> ObterCidadaoCadastrado(Guid id)
        {
            return _mapper.Map<CidadaoViewModel>(await _cidadaoRepositorio.ObterPorId(id));
        }
    }
}