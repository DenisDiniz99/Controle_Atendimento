using System;
using System.Collections.Generic;
using System.Text;

namespace Prefeitura.SysCras.Business.Notifications
{
    public class Notificacao
    {
        //Cria uma Atributo Mensagem para ser apresentada na notificação
        public string Mensagem { get; set; }

        //Construtor que recebe uma mensagem
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
