using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Services;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public RegisterService _registerservice;
        public UsersController(RegisterService registerservice)
        {
            _registerservice = registerservice;
        }
        [HttpPost("adduser")]
        public IActionResult adduser([FromBody] UsersVM user)
        {
            try 
            {
                _registerservice.Addusers(user);
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
    }
}
