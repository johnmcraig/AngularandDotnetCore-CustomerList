using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController() { }

        // GET api/customer
        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Gets()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value" + id;
        }

        // POST api/customer
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}