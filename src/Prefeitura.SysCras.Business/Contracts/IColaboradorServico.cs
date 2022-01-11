using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IColaboradorServico : IDisposable
    {
        Task Adicionar(Colaborador colaborador);
        Task Atualizar(Colaborador colaborador);
        Task Excluir(Colaborador colaborador);
    }
}
