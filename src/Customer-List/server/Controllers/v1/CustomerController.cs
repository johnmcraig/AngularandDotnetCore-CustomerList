using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerApi.Data;
using CustomerApi.Dtos;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo)
        { 
            _repo = repo;
        }

        // GET api/customer
        [HttpGet(Name = nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<Customer> customers = _repo.GetAll().ToList();

            return Ok(customers);
        }

        // GET api/customer/5
        [HttpGet("{id:int}", Name = nameof(GetSingle))]
        public IActionResult GetSingle(int id)
        {
            Customer customer = _repo.GetSingle(id);

            if (customer == null)
                return NotFound();

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

            var customerToAdd = Mapper.Map<Customer>(createDto);

            _repo.Add(customerToAdd);

            if (!_repo.Save())
            {
                throw new Exception("Creating an item failed to save.");
            }
 
            var newCustomer = _repo.GetSingle(customerToAdd.Id);

            return CreatedAtRoute(nameof(GetSingle), 
                new { id = newCustomer.Id}, 
                Mapper.Map<CustomerDto>(newCustomer));
        }

        // PUT api/customer/5
        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateCustomer))]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDto updateCustomerDto)
        { 
            if (updateCustomerDto == null)
            {
                return BadRequest();
            }

            var existingCustomer = _repo.GetSingle(id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            Mapper.Map(updateCustomerDto, existingCustomer);

            _repo.Update(id, existingCustomer);

            if(!_repo.Save())
            {
                throw new Exception("Updating an item failed to save");
            }

            return Ok(Mapper.Map<CustomerDto>(existingCustomer));
        }

        // DELETE api/customer/5
        [HttpDelete]
        [Route("{id:int}", Name = nameof(RemoveCustomer))]
        public IActionResult RemoveCustomer(int id)
        { 
            Customer customer = _repo.GetSingle(id);

            if (customer == null)
            {
                return NotFound();
            }

            _repo.Delete(id);

            if(!_repo.Save())
            {
                throw new Exception("Deleting a Customer failed");
            }

            return NoContent();
        }
    }
}