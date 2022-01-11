using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class ColaboradorServico : BaseServico, IColaboradorServico
    {
        private readonly IColaboradorRepositorio _colaboradorRepositorio;

        public ColaboradorServico(IColaboradorRepositorio colaboradorRepositorio, INotificador notificador) : base(notificador)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
        }

        //Método de serviço para adicionar uma novo colaborador
        public async Task Adicionar(Colaborador colaborador)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um colaborador
            if (!ExecutaValidacao(new ColaboradorValidador(), colaborador)) return;
            await _colaboradorRepositorio.Adicionar(colaborador);
        }

        //Método de serviço para atualizar um colaborador
        public async Task Atualizar(Colaborador colaborador)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza o colaborador
            if (!ExecutaValidacao(new ColaboradorValidador(), colaborador)) return;
            await _colaboradorRepositorio.Atualizar(colaborador);
        }

        //Método de serviço para excluir um colaborador
        public async Task Excluir(Colaborador colaborador)
        {
            await _colaboradorRepositorio.Excluir(colaborador);
        }

        public void Dispose()
        {
            _colaboradorRepositorio?.Dispose();
        }
    }
}
