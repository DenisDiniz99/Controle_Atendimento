using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Validations;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Business.Services
{
    public class AssuntoAtendimentoServico : BaseServico, IAssuntoAtendimentoServico
    {
        private readonly IAssuntoAtendimentoRepositorio _assuntoAtendimentoRepositorio;

        public AssuntoAtendimentoServico(IAssuntoAtendimentoRepositorio assuntoAtendimentoRepositorio, INotificador notificador) : base(notificador)
        {
            _assuntoAtendimentoRepositorio = assuntoAtendimentoRepositorio;
        }

        //Método de serviço para adicionar um novo assunto
        public async Task Adicionar(AssuntoAtendimento assunto)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e adiciona um assunto
            if (!ExecutaValidacao(new AssuntoAtendimentoValidador(), assunto)) return;
            await _assuntoAtendimentoRepositorio.Adicionar(assunto);
        }

        //Método de serviço para atualizar um assunto
        public async Task Atualizar(AssuntoAtendimento assunto)
        {
            //Executa o método de validação passando um novo Validador e uma Entidade
            //Se for encontrado erros na validação, retorna os mesmos
            //Senão, chama o repositório e atualiza um assunto
            if (!ExecutaValidacao(new AssuntoAtendimentoValidador(), assunto)) return;
            await _assuntoAtendimentoRepositorio.Atualizar(assunto);
        }

        //Método de serviço para excluir um assunto
        public async Task Excluir(AssuntoAtendimento assunto)
        {
            await _assuntoAtendimentoRepositorio.Excluir(assunto);
        }

        public void Dispose()
        {
            _assuntoAtendimentoRepositorio?.Dispose();
        }
    }
}
