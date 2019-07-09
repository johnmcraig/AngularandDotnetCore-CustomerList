using System;
using System.Threading.Tasks;
using CustomerApi.Data;
using CustomerApi.Models;

namespace CustomerApi.Services
{
    public class DataSeed : IDataSeed
    {
        public async Task Initialize(CustomerDbContext dbContext)
        {
            dbContext.Customers.Add(new Customer() { Name = "Phil Collins", Age = 45, Position = "Sales Manager", Created = DateTime.Now });
            dbContext.Customers.Add(new Customer() { Name = "Tony Banks", Age = 39, Position = "Consultant", Created = DateTime.Now });
            
            await dbContext.SaveChangesAsync();
        }
    }
}