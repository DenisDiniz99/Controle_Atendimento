using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class CidadaoRepositorio : BaseRepositorio<Cidadao>, ICidadaoRepositorio
    {
        public CidadaoRepositorio(SysContext context) : base(context)
        {

        }

        public async Task<bool> CidadaoExiste(string cpf)
        {
            return await _dbSet.AnyAsync(c => c.Cpf == cpf);
        }
    }
}
