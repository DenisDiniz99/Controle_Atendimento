using Prefeitura.SysCras.Business.Entities;
using System;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ICidadaoRepositorio : IRepositorio<Cidadao> 
    {
        Task<bool> CpfEmUso(string cpf);
        Task<bool> CpfEmUso(Guid id, string cpf);
    }
}
