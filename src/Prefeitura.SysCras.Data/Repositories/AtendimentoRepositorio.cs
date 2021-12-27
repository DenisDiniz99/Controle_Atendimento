using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Data.Context;

namespace Prefeitura.SysCras.Data.Repositories
{
    public class AtendimentoRepositorio : BaseRepositorio<Atendimento>, IAtendimentoRepositorio
    {
        public AtendimentoRepositorio(SysContext context) : base(context)
        {

        }

    }
}
