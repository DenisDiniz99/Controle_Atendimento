using FluentValidation;
using FluentValidation.Results;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Business.Notifications;

namespace Prefeitura.SysCras.Business.Services
{
    public abstract class BaseServico
    {
        private readonly INotificador _notificador;

        public BaseServico(INotificador notificador)
        {
            _notificador = notificador;
        }

        //Recebe uma mensagem de erro e adiciona as notificações
        public void Notificar(string mensagem)
        {
            _notificador.AdicionaNotificacao(new Notificacao(mensagem));
        }

        //Recebe uma ValidationResult, verifica a existencia de erros
        //Se houver adiciona a mensagem de erro ao método Notificar
        public void Notificar(ValidationResult result)
        {
            foreach(var erro in result.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        //Executa a validação
        public bool ExecutaValidacao<TV, TE>(TV validacao, TE entidade) where TV: AbstractValidator<TE> where TE: Entidade
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid) return true;

            Notificar(validador);

            return false;
        }
    }
}
