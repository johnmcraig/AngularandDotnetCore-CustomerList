using System;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Controllers.v1;
using CustomerApi.Data;
using CustomerApi.Models;
using Xunit;

namespace CustomerApiTests
{
    public class CustomerControllerUnitTests
    {
        [Fact]
        public async Task GetAll()
        {
            var controller = new CustomerController(new CustomerRepository());

            // Act
            var result = await controller.GetAll();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<IQueryable<Customer>>().Subject;

            customers.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetSpecific()
        {

        }
    }
}
