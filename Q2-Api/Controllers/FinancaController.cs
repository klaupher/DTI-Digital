using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Q1.Class;
using Q2_Api.Interfaces;
using Q2_Api.Repositories;

namespace Q2_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancaController : ControllerBase
    {

        static readonly IFinancaRepo financasRepo = new FinancaRepo();

        // GET api/getplanos
        [HttpGet]
        public ActionResult<IEnumerable<Financeiro>> GetPlanos()
        {
            List<Financeiro> lstFinanceiros = financasRepo.GetPlanos().ToList();
            return Ok(lstFinanceiros.ToList());
        }

        // GET api/getplano/5
        [HttpGet("{id}")]
        public ActionResult<string> GetPlano(int id)
        {
            return Ok(financasRepo.GetPlanos().Where(x => x.Id == id).FirstOrDefault());
        }

        // GET api/getvalorplano/5
        [HttpGet("{id}")]
        public ActionResult<string> GetValorPlano(int id)
        {
            return Ok(financasRepo.GetPlanos().Where(x => x.Id == id).FirstOrDefault().MontanteFinal());
        }

        // POST api/setplano
        [HttpPost]
        public void SetPlano([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            financasRepo.Remove(id);
        }
    }
}
