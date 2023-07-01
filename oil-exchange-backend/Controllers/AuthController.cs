using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Context;
using oil_exchange_backend.Interfaces;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Services;
using System.Security.Cryptography;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private DataContext _Context { get; set; }
        public AuthController(DataContext Context)
        {
            _Context = Context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserVM>> Register(UserDtoVM request)
        {
            CreatePasswordHash(request.pass, out byte[] passwordHash, out byte[] passwordSalt);
            User _users = new User();
            _users.storename = request.storename;
            _users.phonenumber = request.phonenumber;
            _users.registereddate = DateTime.Now;
            _users.passHash = passwordHash;
            _users.passSalt = passwordSalt;
            _Context.users.Add(_users);
            _Context.SaveChanges();
            return Ok(_users);
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(computedHash);
            }
        }


    }
}
/*try
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
}*/