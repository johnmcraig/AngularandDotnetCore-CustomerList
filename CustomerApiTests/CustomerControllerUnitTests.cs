using System;
using Xunit;

namespace CustomerApiTests
{
    public class CustomerControllerUnitTests
    {
        [Fact]
        public async Task_Values_GetAll()
        {
            var controller = new CustomerController(new CustomerRepository());

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var customers = okResult.Value.Should().BeAssignableTo<IQueryable<Customer>>().Subject;

            customers.Count().Should().Be(1);
        }

        [Fact]
        public async Task_Get_Specific()
        {

        }
    }
}
