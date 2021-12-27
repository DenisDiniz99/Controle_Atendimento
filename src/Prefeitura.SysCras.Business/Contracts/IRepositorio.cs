using Prefeitura.SysCras.Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface IRepositorio<T> where T: BaseEntidade
    {
        Task Adicionar(T entidade);
        Task Atualizar(T entidade);
        Task Excluir(T entidade);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);

        Task<int> SaveChange();
    }
}
