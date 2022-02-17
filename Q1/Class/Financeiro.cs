
using System;

namespace Q1.Class
{
    public class Financeiro: Empresa
    {
        public Financeiro() { }

        public Financeiro(int id, string nome, double entrada, double juros, int periodo, double parcela): base(id, nome){
            Entrada = entrada;
            Juros = juros;
            Periodo = periodo;
            Aporte = parcela;
        }
        
        public double Entrada { get; set; }
        public double Juros { get; set; }
        public int Periodo { get; set; }
        public double Aporte { get; set; }

        public double MontanteFinal()
        {
            double valorPresente = Entrada * (Math.Pow(1 + Juros, Periodo));
            double montante = Aporte * (Math.Pow(1 + Juros, Periodo) - 1) / Juros;
            return valorPresente + Math.Abs(montante);
        }
    }
}