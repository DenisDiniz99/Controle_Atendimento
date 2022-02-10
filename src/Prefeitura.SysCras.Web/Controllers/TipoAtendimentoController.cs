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
    public class TipoAtendimentoController : BaseController
    {
        private readonly ITipoAtendimentoRepositorio _repositorio;
        private readonly ITipoAtendimentoServico _servico;
        private readonly IMapper _mapper;

        public TipoAtendimentoController(INotificador notificador,
                                ITipoAtendimentoRepositorio repositorio,
                                ITipoAtendimentoServico servico,
                                IMapper mapper) : base(notificador)
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }


        //Index: TipoAtendimento
        //Retorna a View com os dados dos Tipos de Atendimento cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TipoAtendimentoViewModel>>(await _repositorio.ObterTodos()));
        }


        //Retorna a View com os dados do Tipo de Atendimento selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        //Retorna a View de Cadastro de Tipo de Atendimento
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Cadastro de Assunto
        [HttpPost]
        public async Task<IActionResult> Cadastrar(TipoAtendimentoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<TipoAtendimento>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach (var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index");

            return LocalRedirect(returnUrl);
        }


        //Retorna a View de Atualização de Tipo de Atendimento
        //Com os dados do tipo de atendimento selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Atualização de Assunto
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, TipoAtendimentoViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<TipoAtendimento>(model));

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


        //Retorna a View de confirmação de exclusão do Tipo de Atendimento selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Exclui o Tipo de Atendimento selecionado
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExclusao(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<TipoAtendimento>(model));

            if (!OperacaoValida())
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }


        //Método privado para pesquisar dados pelo Id
        private async Task<TipoAtendimentoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<TipoAtendimentoViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
