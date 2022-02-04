using Prefeitura.SysCras.Business.Entities;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface ITipoAtendimentoServico
    {
        Task Adicionar(TipoAtendimento tipoAtendimento);
        Task Atualizar(TipoAtendimento tipoAtendimento);
        Task Excluir(TipoAtendimento tipoAtendimento);
    }
}
