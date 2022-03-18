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
    public class CidadaoRepositorio : BaseRepositorio<Cidadao>, ICidadaoRepositorio
    {
        public CidadaoRepositorio(SysContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Cidadao>> ObterTodos()
        {
            return await _dbSet.OrderBy(c => c.DataCad).Skip(0).Take(25).ToListAsync();
        }

        public async Task<bool> CpfEmUso(string cpf)
        {
            return await _dbSet.AnyAsync(c => c.Cpf == cpf);
        }

        public async Task<bool> CpfEmUso(Guid id, string cpf)
        {
            return await _dbSet.AnyAsync(c => c.Id != id && c.Cpf == cpf);
        }

    }
}
