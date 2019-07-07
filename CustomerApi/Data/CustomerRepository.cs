using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetSingle(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Customer item)
        {
            _dbContext.Customers.Add(item);
        }

        public void Delete(int id)
        {
            Customer customer = GetSingle(id);
            _dbContext.Customers.Remove(customer);
        }

        public Customer Update(int id, Customer item)
        {
            _dbContext.Customers.Update(item);
            return item;
        }

        public IQueryable<Customer> GetAll()
        {
            IQueryable<Customer> _allItems = _dbContext.Customers.OrderBy(x => x.Name);
            return _allItems;
        }

        public int Count()
        {
            return _dbContext.Customers.Count();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0;
        }
    }
}