using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class CidadaoRepositorio : BaseRepositorio<Cidadao>, ICidadaoRepositorio
    {
        public CidadaoRepositorio(SysContext context) : base(context)
        {

        }
    }
}
