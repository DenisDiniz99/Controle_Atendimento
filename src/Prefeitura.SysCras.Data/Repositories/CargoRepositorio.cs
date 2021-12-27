using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class CargoRepositorio : BaseRepositorio<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(SysContext context) : base(context)
        {

        }
    }
}
