using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private DataContext _Context;
        private readonly IConfiguration _Configuration;
        public AuthController(DataContext Context, IConfiguration configurstion)
        {
            _Context = Context;
            _Configuration = configurstion;
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
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var comparison = _Context.users.Any(req => req.storename == request.storename);

            if (!comparison)
            {
                return BadRequest("User Not found!");
            }
            else if (comparison)
            {
                var comparison2 = _Context.users.FirstOrDefault(req => req.storename == request.storename);

                byte[] Hash = comparison2.passHash;
                byte[] Salt = comparison2.passSalt;
                
                if (!VerifyPasswordHash(request.pass, Hash, Salt))
                {
                    return BadRequest("password is wrong");
                }
            }
            string token = CreateToken(request);
            return Ok(token);

        }

        private string CreateToken(UserDto request)
        {
            var comparison2 = _Context.users.FirstOrDefault(req => req.storename == request.storename);
            List<Claim> claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, comparison2.storename)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _Configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt; 
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
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
