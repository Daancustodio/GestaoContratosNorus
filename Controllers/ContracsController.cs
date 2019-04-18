using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoContratosNorus.Domain;
using GestaoContratosNorus.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoContratosNorus.Controllers
{
    [Route("api/contract")]
    [ApiController]
    public class ContracsController : ControllerBase
    {
        private IContractRepository repository = new ContractRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Contract>> Get()
        {
            this.repository.Add(new Contract(){
                Id =1,
                ClientName = "Daniel custódio",
                Duration = 6,
                Start = new DateTime(2019,01,01),
                Quantity = 4,
                Type = ContractType.Sale,
                Value = 500.00m
            });
            return this.repository.GetAll();

            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Contract value)
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
        }
    }
}
