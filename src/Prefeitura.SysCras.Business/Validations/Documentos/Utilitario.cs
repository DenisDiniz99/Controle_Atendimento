namespace Prefeitura.SysCras.Business.Validations.Documentos
{
    public class Utilitario
    {
        public static string OnlyNumber(string value)
        {
            var number = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    number += s;
                }
            }
            return number.Trim();
        }
    }
}
