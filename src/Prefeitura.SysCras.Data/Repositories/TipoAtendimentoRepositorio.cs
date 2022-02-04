using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class TipoAtendimentoRepositorio : BaseRepositorio<TipoAtendimento>, ITipoAtendimentoRepositorio
    {
        public TipoAtendimentoRepositorio(SysContext context) : base(context) { }
    }
}
