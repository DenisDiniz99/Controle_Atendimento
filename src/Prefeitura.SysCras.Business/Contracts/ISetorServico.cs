using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ISetorServico : IDisposable
    {
        Task Adicionar(Setor setor);
        Task Atualizar(Setor setor);
        Task Excluir(Setor setor);
    }
}
