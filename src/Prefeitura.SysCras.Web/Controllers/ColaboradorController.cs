using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.Extensions;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public ColaboradorController(INotificador notificador,
                                        IColaboradorRepositorio repositorio,
                                        ICargoRepositorio cargoRepositorio,
                                        IColaboradorServico servico,
                                        UserManager<IdentityUser> userManager,
                                        IUser user,
                                        IMapper mapper) : base(notificador) 
        {
            _repositorio = repositorio;
            _cargoRepositorio = cargoRepositorio;
            _servico = servico;
            _userManager = userManager;
            _user = user;
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
        public async Task<IActionResult> Perfil()
        {
            if (!_user.Autenticado()) return NotFound();

            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);

            var colaborador = _mapper.Map<ColaboradorViewModel>(await ObterPorId(Guid.Parse(user.Id)));

            if (Guid.Parse(user.Id) != colaborador.Id) return BadRequest();

            return View(colaborador);
        }


        //Retorna a View de Cadastro de Colaborador
        public async Task<IActionResult> Cadastrar()
        {
            //Verifica se existe usuário autenticado
            if (!_user.Autenticado()) return NotFound();
            //Se existir usuário autenticado, retorna os dados deste usuário
            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);
            //Verifica se existe colaborador vinculado ao usuário autenticado
            var colaborador = _mapper.Map<ColaboradorViewModel>(await ObterPorId(Guid.Parse(user.Id)));
            //Se existir colaborador, não retorna a página de cadastro
            if (colaborador != null) return BadRequest();
            //Se não existir colaborador, mas existir usuário autenticado
            //Libera a página de cadastro para criar um colaborador vinculado ao usuário logado
            var cargos = _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoRepositorio.ObterTodos());
            ViewBag.Cargos = new SelectList(cargos, "Id", "TituloCargo");
            return View();
        }


        //Cadastro de Colaborador
        [HttpPost]
        public async Task<IActionResult> Cadastrar(ColaboradorViewModel model)
        {
            if (!_user.Autenticado()) return NotFound();

            if (!ModelState.IsValid) return View(model);

            //Obtem os dados do usuário, passando o nome do usuário logado
            var user = await _userManager.FindByNameAsync(_user.NomeUsuario);

            //Atribui ao Colaborador o mesmo Id do Usuário cadastrado
            model.Id = Guid.Parse(user.Id);
            //Atribui Data atual ao DataCad
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

            return RedirectToAction("Index", "Atendimento");
        }


        //Retorna a View de Atualização de Colaborador com os dados do colaborador selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) return NotFound();

            var cargos = _mapper.Map<IEnumerable<CargoViewModel>>(await _cargoRepositorio.ObterTodos());
            ViewBag.Cargos = new SelectList(cargos, "Id", "TituloCargo");

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

            return RedirectToAction("Perfil");
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

            if (OperacaoValida())
            {
                var result = await (ExcluirPerfil(model.Id));
                if (!result)
                {
                    await _servico.Adicionar(_mapper.Map<Colaborador>(model));

                    return BadRequest();
                }

                return RedirectToAction("Sair", "Usuario");
            }

            return BadRequest();
        }



        //Método privado para excluir conta do usuário
        private async Task<bool> ExcluirPerfil(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return true;

            return false;
        }

        //Método privado para pesquisar dados pelo Id
        private async Task<ColaboradorViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _repositorio.ObterPorId(id));
        }
    }
}
