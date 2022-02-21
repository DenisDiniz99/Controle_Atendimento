using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    [Authorize]
    public class AssuntoController : BaseController
    {
        private readonly IAssuntoAtendimentoRepositorio _repositorio;
        private readonly IAssuntoAtendimentoServico _servico;
        private readonly IMapper _mapper;

        public AssuntoController(IAssuntoAtendimentoRepositorio repositorio, IAssuntoAtendimentoServico servico,
                                    IMapper mapper, INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }


        //Index - Assunto
        //Retorna a View com os dados dos Assuntos cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AssuntoAtendimentoViewModel>>(await _repositorio.ObterTodos()));
        }


        //Retorna a View com os dados do Assunto selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        //Retorna a View de Cadastro de Assunto
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Cadastro de Assunto
        [HttpPost]
        public async Task<IActionResult> Cadastrar(AssuntoAtendimentoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<AssuntoAtendimento>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach (var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Index");
        }


        //Retorna a View de Atualização de Assunto com os dados do assunto selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Atualização de Assunto
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, AssuntoAtendimentoViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<AssuntoAtendimento>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach (var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Index");
        }


        //Retorna a View de confirmação de exclusão do Assunto selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Exclui o Assunto selecionado
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExclusao(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<AssuntoAtendimento>(model));

            if (!OperacaoValida())
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }


        //Método privado para pesquisar dados pelo Id
        private async Task<AssuntoAtendimentoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AssuntoAtendimentoViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
