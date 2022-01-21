using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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



        //Método privado para pesquisar dados pelo Id
        private async Task<AtendimentoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AtendimentoViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
