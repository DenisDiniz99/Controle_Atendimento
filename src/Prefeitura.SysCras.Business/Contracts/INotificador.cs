using Prefeitura.SysCras.Business.Notifications;
using System.Collections.Generic;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface INotificador
    {
        void AdicionarNotificacao(Notificacao notificacao);
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
    }
}
