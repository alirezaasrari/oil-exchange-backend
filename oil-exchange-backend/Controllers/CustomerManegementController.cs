using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerManegementController : Controller
    {
        private readonly DataContext _dataContext;

        public CustomerManegementController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpPost("addcustomer"), Authorize]
        public ActionResult<string> Addcustomer(CustomerManagementVM customer)
        {
            try
            {
                CustomerManagement customerManegemant = new CustomerManagement();
                customerManegemant.plaque = customer.plaque;
                customerManegemant.userid = customer.userid;
                customerManegemant.oilfilter = customer.oilfilter;
                customerManegemant.gearboxoil = customer.gearboxoil;
                customerManegemant.airfilter = customer.airfilter;
                customerManegemant.breakeoil = customer.breakeoil;
                customerManegemant.cabinfilter = customer.cabinfilter;
                customerManegemant.engineoil = customer.engineoil;
                customerManegemant.previouskilometer = customer.previouskilometer;
                customerManegemant.nextkilometer = customer.nextkilometer;
                customerManegemant.petrolfilter = customer.petrolfilter;
                customerManegemant.untifreez = customer.untifreez;
                customerManegemant.hydraulicoil = customer.hydraulicoil;
                _dataContext.customermanagement.Add(customerManegemant);
                _dataContext.SaveChanges();
                return Ok("successfully");
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
        public ActionResult<List<CustomerManagement>> getcustomers()
        {
            var Customers = _dataContext.customermanagement.ToList();
            return Ok(Customers);
        }
    }
    }
