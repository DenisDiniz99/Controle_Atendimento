using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class SetorServico : BaseServico, ISetorServico
    {
        private readonly ISetorRepositorio _setorRepositorio;
        
        public SetorServico(INotificador notificador, ISetorRepositorio setorRepositorio) : base(notificador)
        {
            _setorRepositorio = setorRepositorio;
        }

        //Método de serviço para adicionar um novo setor
        public async Task Adicionar(Setor setor)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um setor
            if (!ExecutaValidacao(new SetorValidador(), setor)) return;
            await _setorRepositorio.Adicionar(setor);
        }

        //Método de serviço para atualizar um setor
        public async Task Atualizar(Setor setor)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza um setor
            if (!ExecutaValidacao(new SetorValidador(), setor)) return;
            await _setorRepositorio.Atualizar(setor);
        }

        //Método de serviço para excluir um setor
        public async Task Excluir(Setor setor)
        {
            await _setorRepositorio.Excluir(setor);
        }

        public void Dispose()
        {
            _setorRepositorio?.Dispose();
        }
    }
}
