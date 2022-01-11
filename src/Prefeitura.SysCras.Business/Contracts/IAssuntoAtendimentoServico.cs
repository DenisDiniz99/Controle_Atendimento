using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IAssuntoAtendimentoServico : IDisposable
    {
        Task Adicionar(AssuntoAtendimento assuntoAtendimento);
        Task Atualizar(AssuntoAtendimento assuntoAtendimento);
        Task Excluir(AssuntoAtendimento assuntoAtendimento);
    }
}
