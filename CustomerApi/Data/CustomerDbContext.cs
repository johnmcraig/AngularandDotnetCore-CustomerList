using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base (options)
        {
        }
    }
}