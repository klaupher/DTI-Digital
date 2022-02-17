using Q1.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Threading.Tasks;
using Q2.Interfaces;
using Q2.Repositories;

namespace Q2.Controllers
{
    
    public class FinancasController : ApiController
    {
        static readonly IFinancasRepo financasRepo = new FinancasRepo();


        public HttpResponseMessage GetFinanceiros()
        {
            List<Financeiro> lstFinanceiros = financasRepo.GetFinanceiros().ToList();
            return Request.CreateResponse<List<Financeiro>>(HttpStatusCode.OK, lstFinanceiros);
        }


        public  HttpResponseMessage GetFinanceiro(int id)
        {
            Financeiro financeiro = financasRepo.GetFinanceiro(id);
            return Request.CreateResponse<Financeiro>(HttpStatusCode.OK, financeiro);
        }


        public HttpResponseMessage Add(Financeiro financeiro)
        {
            int novoId = financasRepo.Adiciona(financeiro);
            return Request.CreateResponse<int>(HttpStatusCode.OK, novoId);
        }

        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            financasRepo.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
