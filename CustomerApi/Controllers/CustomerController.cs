using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models;
using CustomerApi.Data;
using CustomerApi.Dtos;
using AutoMapper;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo)
        { 
            _repo = repo;
        }

        // GET api/customer
        [HttpGet(Name = nameof(GetAll))]
        public ActionResult GetAll()
        {
            List<Customer> customers = _repo.GetAll().ToList();

            return Ok(customers);
        }

        // GET api/customer/5
        [HttpGet("{id:int}", Name = nameof(GetSingle))]
        public ActionResult GetSingle(int id)
        {
            Customer customer = _repo.GetSingle(id);

            return Ok(customer);
        }

        // POST api/customer
        [HttpPost(Name = nameof(AddCustomer))]
        public ActionResult<CustomerDto> AddCustomer([FromBody] Customer createDto)
        { 
            if(createDto == null)
            {
                return BadRequest();
            }

            Customer customerToAdd = Mapper.Map<Customer>(createDto);

            _repo.Add(customerToAdd);

            if (!_repo.Save())
            {
                throw new Exception("Creating a Customer failed.");
            }
 
            Customer newCustomer = _repo.GetSingle(customerToAdd.Id);

            return CreatedAtRoute(nameof(GetSingle), 
                new { id = newCustomer.Id}, 
                Mapper.Map<CustomerDto>(newCustomer));
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}