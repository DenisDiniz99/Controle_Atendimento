using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class AssuntoAtendimentoRepositorio : BaseRepositorio<AssuntoAtendimento>, IAssuntoAtendimentoRepositorio
    {
        public AssuntoAtendimentoRepositorio(SysContext context) : base(context)
        {

        }
    }
}
