using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApi.Models;

namespace CustomerApi.Data
{
    public interface IGenericRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void Update<T>(T entity, int id) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Customer>> GetAll();
         Task<Customer> GetSingle(int id);
    }
}