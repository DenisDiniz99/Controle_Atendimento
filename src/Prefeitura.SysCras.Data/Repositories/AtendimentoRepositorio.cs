using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class AtendimentoRepositorio : BaseRepositorio<Atendimento>, IAtendimentoRepositorio
    {
        public AtendimentoRepositorio(SysContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Atendimento>> ObterTodosPorColaborador(Guid colaboradorId)
        {
            var result = await _dbSet.Where(a => a.ColaboradorId == colaboradorId).OrderBy(a => a.DataAtualizacao).ToListAsync();
            return result;
        }
    }
}
