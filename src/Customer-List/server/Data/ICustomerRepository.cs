using System.Linq;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public interface ICustomerRepository
    {
        void Add(Customer item);
        void Delete(int id);
        Customer Update(int id, Customer item);
        Customer GetSingle(int id);
        bool Save();
        IQueryable<Customer> GetAll();
        int Count();
    }
}