using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class GenericRepository : IGenericRepository
    {
        private readonly CustomerDbContext _dbContext;

        public GenericRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetSingle(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity, int id) where T : class
        {
            _dbContext.Update(entity);
        }
    }
}