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

        public override async Task<IEnumerable<Atendimento>> ObterTodos()
        {
            return await _dbSet.OrderBy(a => a.DataHoraAtualizacao)
                .Include(a => a.AssuntoAtendimento)
                .Include(c => c.Cidadao)
                .ToListAsync();
        }

        //public async Task AtualizarStatus(Guid id, int statusAtendimento, DateTime dataAtualizacao)
        //{
        //    var atendimento = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);
        //    atendimento.StatusAtendimento = (StatusAtendimento)statusAtendimento;
        //    atendimento.DataHoraAtendimento = dataAtualizacao;
        //    _context.Atendimentos.Attach(atendimento).Property(p => p.StatusAtendimento).IsModified = true;
        //    _context.Atendimentos.Attach(atendimento).Property(p => p.DataHoraAtendimento).IsModified = true;
        //    await SaveChange();
        //}

    }
}
