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
        }

        [HttpGet(Name = nameof(GetAll))]
        public async Task<ActionResult<Customer>> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            
            if(customers == null) return NotFound();

            return Ok(customers);
        }

        [HttpGet("{id:int}", Name = nameof(GetSingle))]
        public async Task<ActionResult<Customer>> GetSingle(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if( customer == null) return NotFound();

            return Ok(customer);
        }

        [HttpPost(Name = nameof(AddCustomer))]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
             _dbContext.Customers.Add(customer);
             await _dbContext.SaveChangesAsync();

            if(customer == null) return BadRequest();

            return CreatedAtRoute(nameof(GetSingle), 
                new { id = customer.Id }, customer);
        }

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateCustomer))]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if( id != customer.Id) return BadRequest();

            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}", Name = nameof(DeleteCustomer))]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if( customer == null) return NotFound();

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}