using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    public class ColaboradorController :  BaseController
    {
        private readonly IColaboradorRepositorio _repositorio;
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IColaboradorServico _servico;
        private readonly IMapper _mapper;

        public ColaboradorController(INotificador notificador,
                                        IColaboradorRepositorio repositorio,
                                        ICargoRepositorio cargoRepositorio,
                                        IColaboradorServico servico,
                                        IMapper mapper) : base(notificador) 
        {
            _repositorio = repositorio;
            _cargoRepositorio = cargoRepositorio;
            _servico = servico;
            _mapper = mapper;
        }


        //Index - Colaborador
        //Retorna a View com os dados dos Colaboradores cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ColaboradorViewModel>>(await _repositorio.ObterTodos()));
        }

        //Retorna a View com os dados do Colaborador selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //Retorna a View de Perfil do Colaborador
        public async Task<IActionResult> Perfil(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View();
        }


        //Retorna a View de Cadastro de Colaborador
        public async Task<IActionResult> Cadastrar()
        {
            var cargos = _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoRepositorio.ObterTodos());
            ViewBag.Cargos = new SelectList(cargos, "Id", "TituloCargo");
            return View();
        }


        //Cadastro de Colaborador
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ColaboradorViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(model);

            model.DataCad = DateTime.Now;

            await _servico.Adicionar(_mapper.Map<Colaborador>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach(var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Perfil");
        }


        //Retorna a View de Atualização de Colaborador com os dados do colaborador selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        //Atualização do Colaborador
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, ColaboradorViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<Colaborador>(model));

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


        //Retorna a View de confirmação de exclusão do Colaborador selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }


        //Exclui o Colaborador selecionado
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExclusao(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<Colaborador>(model));

            if (!OperacaoValida()) return BadRequest();

            return RedirectToAction("Index");
        }


        //Método privado para pesquisar dados pelo Id
        private async Task<ColaboradorViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
