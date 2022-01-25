using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IAtendimentoRepositorio : IRepositorio<Atendimento>
    {
        Task<IEnumerable<Atendimento>> ObterTodosPorColaborador(Guid colaboradorId);
    }
}
