using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("addcustomer")]
        public async Task<ActionResult<string>> Addcustomer(CustomerManagementVM customer)
        {
            try
            {
                CustomerManagement customerManegemant = new()
                {
                    plaque = customer.plaque,
                    userid = customer.userid,
                    oilfilter = customer.oilfilter,
                    gearboxoil = customer.gearboxoil,
                    airfilter = customer.airfilter,
                    breakeoil = customer.breakeoil,
                    cabinfilter = customer.cabinfilter,
                    engineoil = customer.engineoil,
                    previouskilometer = customer.previouskilometer,
                    nextkilometer = customer.nextkilometer,
                    petrolfilter = customer.petrolfilter,
                    untifreez = customer.untifreez,
                    hydraulicoil = customer.hydraulicoil
                };
                _dataContext.customermanagement.Add(customerManegemant);
                await _dataContext.SaveChangesAsync();
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
        [HttpGet("get-userid")]
        public async Task<ActionResult<int>> Userid(string storename)
        {
            var user = await _dataContext.users.FirstOrDefaultAsync(req => req.Storename == storename);
            if (user is not null)
            {
                var id = user.Id;
                return Ok(id);
            }else { return BadRequest(0); }
        }

        [HttpGet("getcustomers")]
        public async Task<ActionResult<List<CustomerManagement>>> Getcustomers(int userid)
        {
            var Customers = await _dataContext.customermanagement.Where(req => req.userid == userid).ToListAsync();
            return Ok(Customers);
        }
    }
    }
