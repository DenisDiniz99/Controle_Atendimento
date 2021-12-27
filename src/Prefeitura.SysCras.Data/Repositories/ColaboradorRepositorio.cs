using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class ColaboradorRepositorio : BaseRepositorio<Colaborador>, IColaboradorRepositorio
    {
        public ColaboradorRepositorio(SysContext context) : base(context)
        {

        }
    }
}
