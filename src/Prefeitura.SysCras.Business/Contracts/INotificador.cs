using Prefeitura.SysCras.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prefeitura.SysCras.Business.Contracts
{
    public interface INotificador
    {
        void AdicionaNotificacao(Notificacao notificacao);
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
    }
}
