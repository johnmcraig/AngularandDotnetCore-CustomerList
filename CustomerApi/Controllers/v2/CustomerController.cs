using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerController(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;

            if(_dbContext.Customers.Count() == 0)
                _dbContext.Add(new Customer
                {
                    Name = "Bob", 
                    Age = 40, 
                    Position = "Sales Manager"
                });
                _dbContext.SaveChanges();

        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            
            if(customers == null)
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Customer>> GetSingle(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if( customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
             await _dbContext.Customers.AddAsync(customer);
             await _dbContext.SaveChangesAsync();

            if(customer == null)
                return BadRequest("Customer could not be added");

            return CreatedAtAction(nameof(GetSingle), 
                new
                { 
                    id = customer.Id,
                    name = customer.Name,
                    position = customer.Position,
                    age = customer.Age 
                },
                customer);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if( id != customer.Id)
                return BadRequest();

            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if( customer == null)
                return NotFound();

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}