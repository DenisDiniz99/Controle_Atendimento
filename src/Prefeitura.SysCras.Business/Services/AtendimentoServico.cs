using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class AtendimentoServico : BaseServico
    {
        private readonly IAtendimentoRepositorio _atendimentoRepositorio;

        public AtendimentoServico(IAtendimentoRepositorio atendimentoRepositorio, INotificador notificador) : base(notificador)
        {
            _atendimentoRepositorio = atendimentoRepositorio;
        }

        //Método de serviço para adicionar um novo atendimento
        public async Task Adicionar(Atendimento atendimento)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um atendimento
            if (!ExecutaValidacao(new AtendimentoValidador(), atendimento)) return;
            await _atendimentoRepositorio.Adicionar(atendimento);
        }

        //Método de serviço para atualizar um atendimento
        public async Task Atualizar(Atendimento atendimento)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza um atendimento
            if (!ExecutaValidacao(new AtendimentoValidador(), atendimento)) return;
            await _atendimentoRepositorio.Atualizar(atendimento);
        }

        //Método de serviço para excluir um atendimento
        public async Task Excluir(Atendimento atendimento)
        {
            await _atendimentoRepositorio.Excluir(atendimento);
        }

        public void Dispose()
        {
            _atendimentoRepositorio?.Dispose();
        }
    }
}
