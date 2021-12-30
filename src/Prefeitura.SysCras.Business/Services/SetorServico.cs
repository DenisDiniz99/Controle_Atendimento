using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class SetorServico : BaseServico
    {
        private readonly ISetorRepositorio _setorRepositorio;
        
        public SetorServico(INotificador notificador, ISetorRepositorio setorRepositorio) : base(notificador)
        {
            _setorRepositorio = setorRepositorio;
        }

        public async Task Adicionar(Setor setor)
        {
            if(!ExecutaValidacao(new SetorValidation))
            await _setorRepositorio.Adicionar(setor);
        }

        public async Task Atualizar(Setor setor)
        {
            await _setorRepositorio.Atualizar(setor);
        }

        public async Task Excluir(Setor setor)
        {
            await _setorRepositorio.Excluir(setor);
        }
    }
}
