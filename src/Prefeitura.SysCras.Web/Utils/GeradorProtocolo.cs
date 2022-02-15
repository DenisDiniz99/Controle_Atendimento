using System;

namespace Prefeitura.SysCras.Web.Utils
{
    public static class GeradorProtocolo
    {
        public static int NumProtocolo()
        {
            var num = new Random();
            return num.Next();
        }
    }
}
