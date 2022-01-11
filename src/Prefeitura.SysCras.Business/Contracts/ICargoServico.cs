using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ICargoServico : IDisposable
    {
        Task Adicionar(Cargo cargo);
        Task Atualizar(Cargo cargo);
        Task Excluir(Cargo cargo);
    }
}
