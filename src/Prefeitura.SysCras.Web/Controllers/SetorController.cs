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
    public class SetorController : BaseController
    {
        private readonly ISetorServico _servico;
        private readonly ISetorRepositorio _repositorio;
        private readonly IMapper _mapper;

        public SetorController(INotificador notificador, ISetorServico servico, ISetorRepositorio repositorio, IMapper mapper) : base(notificador)
        {
            _servico = servico;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        //Index - Setores
        //Retorna a View com os dados dos Setores cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<SetorViewModel>>(await _repositorio.ObterTodos()));
        }


        //Retorna a View com os dados do Setor selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var setor = _mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id));

            if (setor == null) return NotFound();

            return View(setor);
        }


        //Retorna a View de Cadastro de Setor
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Cadastro de Setor
        [HttpPost]
        public async Task<IActionResult> Cadastrar(SetorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<Setor>(model));

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


        //Retorna a View de Atualização de Setor com os dados do setor selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = _mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id));

            if (model == null) return NotFound();

            return View(model);
        }

        //Atualização de Setor
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, SetorViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<Setor>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Index");
        }


        //Retorna a View de confirmação de exclusão do Setor selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = _mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id));

            if (model == null) return NotFound();

            return View(model);
        }

        //Exclusão de Setor
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExcluao(Guid id)
        {
            var model = _mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id));

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<Setor>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Index");
        }
    }
}
