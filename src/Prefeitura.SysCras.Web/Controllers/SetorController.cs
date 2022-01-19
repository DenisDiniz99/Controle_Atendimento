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

        [HttpGet]
        public async Task<IActionResult> Detalhes()
        {
            return View(_mapper.Map<IEnumerable<SetorViewModel>>(await _repositorio.ObterTodos()));
        }

        [HttpGet]
        public async Task<IActionResult> DetalhesPorId(Guid id)
        {
            return View(_mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id)));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(SetorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<Setor>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Detalhes");
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, SetorViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<Setor>(model));

            if (!OperacaoValida()) return View(model);

            return RedirectToAction("Detalhes");
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = _mapper.Map<SetorViewModel>(await _repositorio.ObterPorId(id));

            if (model == null) return NotFound();

            await _servico.Excluir(_mapper.Map<Setor>(model));

            if (!OperacaoValida()) return View(model);

            return View();
        }
    }
}
