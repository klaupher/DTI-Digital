using Q1.Class;
using Q2.Interfaces;
using Q2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Q2.Repositories
{
    public class FinancasRepo : IFinancasRepo
    {
        static readonly string arqXML = HttpContext.Current.Server.MapPath("~/app_data/empresas.xml");

        public int Adiciona(Financeiro financeiro)
        {
            int proxID = GetFinanceiros().OrderByDescending(x => x.Id).First().Id + 1;
            
            DataSet empresas = new DataSet();
            empresas.ReadXml(arqXML);
            financeiro.Id = proxID;
            empresas.Tables[0].Rows.Add(GetRow(empresas,financeiro));
            empresas.AcceptChanges();
            empresas.WriteXml(arqXML, XmlWriteMode.IgnoreSchema);
            return proxID;

        }

        public Financeiro GetFinanceiro(int id)
        {
            return GetFinanceiros().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Financeiro> GetFinanceiros()
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
            List<Financeiro> lstFinanceiros = GetFinanceiros().ToList();
            Financeiro financeiro = GetFinanceiros().Where(x => x.Id == id).FirstOrDefault();
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
}