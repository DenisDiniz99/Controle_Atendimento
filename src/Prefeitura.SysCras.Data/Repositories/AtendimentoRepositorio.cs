using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class AtendimentoRepositorio : BaseRepositorio<Atendimento>, IAtendimentoRepositorio
    {
        public AtendimentoRepositorio(SysContext context) : base(context)
        {

        }

        public async Task AtualizarStatus(Guid id, StatusAtendimento statusAtendimento)
        {
            var atendimento = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
            atendimento.StatusAtendimento = statusAtendimento;
            _context.Atendimentos.Attach(atendimento).Property(p => p.StatusAtendimento).IsModified = true;
            await SaveChange();
        }

    }
}
