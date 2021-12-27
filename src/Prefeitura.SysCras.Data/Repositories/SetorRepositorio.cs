using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class SetorRepositorio : BaseRepositorio<Setor>, ISetorRepositorio
    {
        public SetorRepositorio(SysContext context) : base(context)
        {

        }
    }
}
