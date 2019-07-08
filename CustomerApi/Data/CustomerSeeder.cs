using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerSeeder
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerSeeder(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            await _dbContext.Database.EnsureCreatedAsync();

            if(!_dbContext.Customers.Any())
            {
                SeedCustomers();
                await _dbContext.SaveChangesAsync();
            }
            
        }

        private void SeedCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer() { Name = "Phil Collins", Age = 45, Position = "Sales Manager", Created = DateTime.Now },
                new Customer() { Name = "Tony Banks", Age = 39, Position = "Consultant", Created = DateTime.Now }
            };

            _dbContext.Customers.AddRange(customers);
        }
    }
}