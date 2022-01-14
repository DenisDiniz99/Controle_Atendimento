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
    public class ColaboradorController :  BaseController
    {
        private readonly IColaboradorRepositorio _repositorio;
        private readonly IColaboradorServico _servico;
        private readonly IMapper _mapper;
        
        public ColaboradorController(INotificador notificador, 
                                        IColaboradorRepositorio repositorio,
                                        IColaboradorServico servico,
                                        IMapper mapper) : base(notificador) 
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }


        //Retorna a View com Inicial de Colaboradores
        [Route("colaboradores")]
        public async Task<IActionResult> Detalhes()
        {
            return View(_mapper.Map<IEnumerable<ColaboradorViewModel>>(await _repositorio.ObterTodos()));
        }

        [Route("colaborador-id/{id:guid}")]
        public async Task<IActionResult> DetalhesPorId(Guid id)
        {
            var model = await _repositorio.ObterPorId(id);

            if (model == null) return NotFound();

            return View(model);
        }

        [Route("adicionar-colaborador")]
        public async Task<IActionResult> Adicionar(ColaboradorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _servico.Adicionar(_mapper.Map<Colaborador>(model));

            return RedirectToAction("Detalhes", "Colaborador");
        }

        [Route("atualizar-colaborador")]
        public async Task<IActionResult> Atualizar(ColaboradorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _servico.Atualizar(_mapper.Map<Colaborador>(model));

            return RedirectToAction("Detalhes", "Colaborador");
        }

        [Route("excluir-colaborador")]
        public async Task<IActionResult> Excluir(ColaboradorViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _servico.Excluir(_mapper.Map<Colaborador>(model));

            return RedirectToAction("Detalhes", "Colaborador");
        }
    }
}
