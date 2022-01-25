using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class AtendimentoController : BaseController
    {
        private readonly IAtendimentoRepositorio _repositorio;
        private readonly IAtendimentoServico _servico;
        private readonly IMapper _mapper;

        public AtendimentoController(IAtendimentoRepositorio repositorio,
                                        IAtendimentoServico servico,
                                        IMapper mapper,
                                        INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            return View(_mapper.Map<IEnumerable<AtendimentoViewModel>>(await _repositorio.ObterTodosPorColaborador(id)));
        }


        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        public IActionResult Novo()
        {
            return View();
        }

        public async Task<IActionResult> Novo(AtendimentoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

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

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AtualizarStatus(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

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
    }
}
