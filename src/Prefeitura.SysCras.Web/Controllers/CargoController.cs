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
    public class CargoController : BaseController
    {
        private readonly ICargoRepositorio _repositorio;
        private readonly ICargoServico _servico;
        private readonly IMapper _mapper;

        public CargoController(ICargoRepositorio repositorio, ICargoServico servico, IMapper mapper, INotificador notificado) : base(notificado)
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }

        //Index - Cargos
        //Retorna a View com os dados dos Cargos cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CargoViewModel>>(await _repositorio.ObterTodos()));
        }


        //Retorna a View com os dados do Cargo selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        //Retorna a View de Cadastro de Cargo
        public IActionResult Cadastrar()
        {
            return View();
        }

        //Cadastro de Setor
        [HttpPost]
        public async Task<IActionResult> Cadastrar(SetorViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<Cargo>(model));

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


        //Retorna a View de Atualização de Cargo com os dados do cargo selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Atualização de Cargo
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, SetorViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<Cargo>(model));

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


        //Retorna a View de confirmação de exclusão do Cargo selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Exclui o Cargo selecionado
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExcluao(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<Cargo>(model));

            if (!OperacaoValida())
            {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }


        //Método privado para pesquisar dados pelo Id
        private async Task<CargoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CargoViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
