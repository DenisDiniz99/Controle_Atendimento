using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class CidadaoRepositorio : BaseRepositorio<Cidadao>, ICidadaoRepositorio
    {
        public CidadaoRepositorio(SysContext context) : base(context)
        {

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
