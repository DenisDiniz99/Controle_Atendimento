using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IAtendimentoServico : IDisposable
    {
        Task Adicionar(Atendimento atendimento);
        Task AtualizarStatus(Guid id, StatusAtendimento statusAtendimento);
    }
}
