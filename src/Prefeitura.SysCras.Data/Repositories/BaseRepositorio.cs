using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public abstract class BaseRepositorio<T> : IRepositorio<T> where T : Entidade
    {
        protected readonly SysContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepositorio(SysContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public virtual async Task Adicionar(T entidade)
        {
            _dbSet.Add(entidade);
            await SaveChange();
        }

        public virtual async Task Atualizar(T entidade)
        {
            _dbSet.Update(entidade);
            await SaveChange();
        }

        public virtual async Task Excluir(T entidade)
        {
            _dbSet.Remove(entidade);
            await SaveChange();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> SaveChange()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
