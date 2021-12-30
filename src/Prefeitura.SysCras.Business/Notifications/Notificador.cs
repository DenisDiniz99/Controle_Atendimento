using Prefeitura.SysCras.Business.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Prefeitura.SysCras.Business.Notifications
{
    public class Notificador : INotificador
    {
        //Cria uma lista de Notificações
        private readonly List<Notificacao> _notificacoes;

        //Construtor para criar uma nova lista de notificações
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        //Adiciona uma Notificação à lista de notificações
        public void AdicionaNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        //Obtem a lista de notificações existentes
        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        //Verifica se tem alguma notificação na lista de notificações
        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
