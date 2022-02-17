using Q1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Q1.Helpers
{
    static class Funcoes
    {
        public static Financeiro MenorMontante(IEnumerable<Financeiro> entidades)
        {
            Financeiro retorno = entidades.FirstOrDefault();
            foreach (Financeiro item in entidades)
            {
                if (item.MontanteFinal() < retorno.MontanteFinal())
                {
                    retorno = item;
                }
            }
            return retorno;
        }

    }
}
