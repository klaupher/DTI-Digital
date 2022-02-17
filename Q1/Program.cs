using Q1.Class;
using Q1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Financeiro> empresas = new List<Financeiro>();
            empresas.Add(new Financeiro(1, "Empresa A", 10000, 0.01, (10 * 12), 500.00));
            empresas.Add(new Financeiro(1, "Empresa B", 30000, 0.007, (8 * 12), 500.00));
            empresas.Add(new Financeiro(1, "Empresa C", 5000, 0.015, (12 * 12), 600.00));
            empresas.Add(new Financeiro(1, "Empresa D", 50000, 0.005, (10 * 12), 350.00));

            foreach (Financeiro empresa in empresas)
            {
                Console.WriteLine($"Montante {empresa.Nome}: R$ {empresa.MontanteFinal().ToString("0.##")}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Empresa onde pagarei menos: {Funcoes.MenorMontante(empresas).Nome}");
            Console.ReadKey();
        }
    }
}
