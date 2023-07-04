using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Services;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManegementController : Controller
    {
        public CustomerManegemantService _customerManegemantService { get; set; }
        public CustomerManegementController(CustomerManegemantService customerManegemantService)
        {
            _customerManegemantService = customerManegemantService;
        }
        [HttpPost("addcustomer"), Authorize]
        public async Task<IActionResult> Addcustomer([FromBody] CustomerManagementVM customerManagement)
        {
            try
            {
                _customerManegemantService.AddCustomer(customerManagement);
                return Ok();
            }
            catch (Exception ex)
            {
                var ineerexception = ex.InnerException;
                if (ineerexception != null)
                {
                    return BadRequest(ineerexception.Message);
                }
                else
                {
                    return BadRequest("bad request");
                }
            }
        }

        [HttpGet("getcustomers")]
        public async Task<ActionResult<List<CustomerManagement>>> getcustomers()
        {
            var Customers = _customerManegemantService.GetCustomers();
            return Ok(Customers);
        }
    }
}
