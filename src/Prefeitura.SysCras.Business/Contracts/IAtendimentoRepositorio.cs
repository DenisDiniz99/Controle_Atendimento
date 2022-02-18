using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IAtendimentoRepositorio : IRepositorio<Atendimento>
    {
        //Task AtualizarStatus(Guid id, int statusAtendimento, DateTime dataAtualizacao);
    }
}
