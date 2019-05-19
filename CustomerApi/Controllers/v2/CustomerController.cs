using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult Gets()
        {
            return Ok("This is version 2.0 of the customer controller");
        }
    }
}