using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class TipoAtendimentoServico : BaseServico, ITipoAtendimentoServico
    {
        private readonly ITipoAtendimentoRepositorio _tipoAtendimentoRepositorio;
        public TipoAtendimentoServico(INotificador notificador,
                                        ITipoAtendimentoRepositorio tipoAtendimentoRepositorio) : base(notificador) 
        {
            _tipoAtendimentoRepositorio = tipoAtendimentoRepositorio;
        }

        //Método de serviço para adicionar um novo tipo de atendimento
        public async Task Adicionar(TipoAtendimento tipoAtendimento)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um tipo de atendimento
            if (!ExecutaValidacao(new TipoAtendimentoValidator(), tipoAtendimento)) return;
            await _tipoAtendimentoRepositorio.Adicionar(tipoAtendimento);
        }

        //Método de serviço para atualizar um tipo de atendimento
        public async Task Atualizar(TipoAtendimento tipoAtendimento)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza o tipo de atendimento
            if (!ExecutaValidacao(new TipoAtendimentoValidator(), tipoAtendimento)) return;
            await _tipoAtendimentoRepositorio.Atualizar(tipoAtendimento);
        }

        //Método de serviço para excluir um tipo de atendimento
        public async Task Excluir(TipoAtendimento tipoAtendimento)
        {
            await _tipoAtendimentoRepositorio.Excluir(tipoAtendimento);
        }

        public void Dispose()
        {
            _tipoAtendimentoRepositorio?.Dispose();
        }
    }
}
