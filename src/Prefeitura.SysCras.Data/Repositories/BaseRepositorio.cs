using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public abstract class BaseRepositorio<T> : IRepositorio<T> where T : BaseEntidade
    {
        private readonly SysContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepositorio(SysContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task Adicionar(T entidade)
        {
            _dbSet.Add(entidade);
            await SaveChange();
        }

        public async Task Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            await SaveChange();
        }

        public async Task Excluir(T entidade)
        {
            _dbSet.Remove(entidade);
            await SaveChange();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
