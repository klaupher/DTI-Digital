using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Q1.Class;
using Q2_Api.Interfaces;
using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Q2_Api.Repositories
{
    public class FinancaRepo : IFinancaRepo
    {
        static readonly string arqXML = ServerLocal.MapPath("empresas.xml");

        public int AddPlano(Financeiro financeiro)
        {
            int proxID = GetPlanos().OrderByDescending(x => x.Id).First().Id + 1;

            DataSet empresas = new DataSet();
            empresas.ReadXml(arqXML);
            financeiro.Id = proxID;
            empresas.Tables[0].Rows.Add(GetRow(empresas, financeiro));
            empresas.AcceptChanges();
            empresas.WriteXml(arqXML, XmlWriteMode.IgnoreSchema);
            return proxID;
        }

        public Financeiro GetPlano(int id)
        {
            return GetPlanos().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Financeiro> GetPlanos()
        {
            DataSet empresas = new DataSet();
            empresas.ReadXml(arqXML);

            List<Financeiro> financeiros = new List<Financeiro>();
            foreach (DataRow empresa in empresas.Tables[0].Rows)
            {
                Financeiro financeiro = new Financeiro();
                financeiro.Id = Convert.ToInt32(empresa["id"]);
                financeiro.Nome = empresa["nome"].ToString();
                financeiro.Entrada = Convert.ToDouble(empresa["entrada"]);
                financeiro.Juros = Convert.ToDouble(empresa["juros"]);
                financeiro.Periodo = Convert.ToInt32(empresa["periodo"]);
                financeiro.Aporte = Convert.ToDouble(empresa["aporte"]);
                financeiros.Add(financeiro);
            }

            return financeiros.ToList();
        }

        public void Remove(int id)
        {
            List<Financeiro> lstFinanceiros = GetPlanos().ToList();
            Financeiro financeiro = GetPlanos().Where(x => x.Id == id).FirstOrDefault();
            DataSet empresas = new DataSet();
            empresas.ReadXml(arqXML);
            empresas.Tables[0].Rows.Remove(GetRow(empresas, financeiro));
            empresas.AcceptChanges();
            empresas.WriteXml(arqXML, XmlWriteMode.IgnoreSchema);
        }

        public bool Update(Financeiro financeiro)
        {
            throw new NotImplementedException();
        }

        private DataRow GetRow(DataSet dataSet, Financeiro financeiro)
        {
            DataRow node = dataSet.Tables[0].NewRow();
            node["id"] = financeiro.Id;
            node["nome"] = financeiro.Nome;
            node["entrada"] = financeiro.Entrada.ToString();
            node["juros"] = financeiro.Juros.ToString();
            node["periodo"] = financeiro.Periodo.ToString();
            node["aporte"] = financeiro.Aporte.ToString();

            return node;
        }
    }

    public static class ServerLocal
    {
        public static string MapPath(string path)
        {
            return Path.Combine(
                (string)AppDomain.CurrentDomain.GetData("ContentRootPath"),
                path);
        }
    }
}
