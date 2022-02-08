using Prefeitura.SysCras.Business.Entities;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ICidadaoRepositorio : IRepositorio<Cidadao> 
    {
        Task<bool> CidadaoExiste(string cpf);
    }
}
