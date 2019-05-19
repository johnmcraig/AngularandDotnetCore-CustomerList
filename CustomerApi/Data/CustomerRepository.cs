using System;
using System.Collections.Concurrent;
using System.Linq;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// A repository pattern to store a list of customers in data as a dictionary
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <typeparam name="Customer"></typeparam>
        /// <returns></returns>
        private readonly ConcurrentDictionary<int, Customer> _storage = new ConcurrentDictionary<int, Customer>();

        public Customer GetSingle(int id)
        {
            return _storage.TryGetValue(id, out var item) ? item : null;
        }

        public void Add(Customer item)
        {
            item.Id = !_storage.Values.Any() ? 1 : _storage.Values.Max(x => x.Id) + 1;

            if(!_storage.TryAdd(item.Id, item))
            {
                throw new Exception("Item could not be added");
            }
        }

        public void Delete(int id)
        {
            if(!_storage.TryRemove(id, out var item))
            {
                throw new Exception("Item could not be removed");
            }
        }

        public Customer Update(int id, Customer item)
        {
            _storage.TryUpdate(id, item, GetSingle(id));
            return item;
        }

        public IQueryable<Customer> GetAll()
        {
            IQueryable<Customer> _allItems = _storage.Values.AsQueryable();
            return _allItems;
        }

        public int Count()
        {
            return _storage.Count;
        }

        public bool Save()
        {
            return true;
        }
    }
}