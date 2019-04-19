using System;
using System.Collections.Generic;
using GestaoContratosNorus.Domain;
using GestaoContratosNorus.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GestaoContratosNorus.Controllers
{
    [Route("api/contract")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ContracsController : ControllerBase
    {
        private IContractRepository repository = new ContractRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Contract>> Get()
        {
            var all = this.repository.GetAll();
            return Ok(all);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Contract value)
        {
            
            try
            {
                var retorno = this.repository.Add(value);
               return Ok(retorno);    
            }
            catch (Exception ex)
            {                
                
               return BadRequest(ex);
                
            }
            
        }

        // PUT api/values/5
        [HttpPost("Edit")]
        public ActionResult Put([FromBody] Contract value)
        {
            try
            {
                this.repository.Update(value);
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpPost("delete")]
        public ActionResult Delete([FromBody] List<string> ids)
        {
            try
            {
                ids.ForEach(x => {
                    this.repository.Remove(x);
                });
                return Ok(true);               
            }
            catch (System.Exception ex)
            {                
                return BadRequest(ex);
            }
        }  
       
    }
}
