using Q1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2.Interfaces
{
    interface IFinancasRepo
    {
        IEnumerable<Financeiro> GetFinanceiros();
        Financeiro GetFinanceiro(int id);
        int Adiciona(Financeiro financeiro);
        void Remove(int id);
        bool Update(Financeiro financeiro);
    }
}
