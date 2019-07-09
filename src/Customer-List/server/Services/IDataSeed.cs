using System.Threading.Tasks;
using CustomerApi.Data;

namespace CustomerApi.Services
{
    public interface IDataSeed
    {
         Task Initialize(CustomerDbContext dbContext);
    }
}