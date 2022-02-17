using Q1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q2_Api.Interfaces
{
    interface IFinancaRepo
    {
        IEnumerable<Financeiro> GetPlanos();
        Financeiro GetPlano(int id);
        int AddPlano(Financeiro financeiro);
        void Remove(int id);
        bool Update(Financeiro financeiro);
    }
}
