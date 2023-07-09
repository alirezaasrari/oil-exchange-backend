using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly DataContext _Context;
        public AuthController(DataContext Context)
        {
            _Context = Context;
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserVM>> Register(UserDtoVM request)
        {
            CreatePasswordHash(request.Pass, out byte[] passwordHash, out byte[] passwordSalt);
            User _users = new()
            {
                Storename = request.Storename,
                Phonenumber = request.Phonenumber,
                Registereddate = DateTime.Now,
                PassHash = passwordHash,
                PassSalt = passwordSalt
            };
            _Context.Users.Add(_users);
            await _Context.SaveChangesAsync();
            return Ok(_users);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(req => req.Storename == request.Storename);
            if (user is not null)
            {
                var comparison = await _Context.Users.AnyAsync(req => req.Storename == request.Storename);

                if (!comparison)
                {
                    return BadRequest("User Not found!");
                }
                else if (comparison)
                {
                    var comparison2 = await _Context.Users.FirstOrDefaultAsync(req => req.Storename == request.Storename);
                    if (comparison2 is not null)
                    {
                        byte[] Hash = comparison2.PassHash;
                        byte[] Salt = comparison2.PassSalt;

                        if (!VerifyPasswordHash(request.Pass, Hash, Salt))
                        {
                            return BadRequest("password is wrong");
                        }
                    }
                    string token = await Createtoken(user);
                    user.Token = token;
                    await _Context.SaveChangesAsync();
                    return Ok(token);
                }
                else { return BadRequest("user not found"); }
            }else { return BadRequest("user not found"); }
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(string storename)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(u => u.Storename == storename);
            if (user == null)
            {
                return BadRequest("user not found!");
            }
            user.Passwordresettoken = await Createtoken(user);
            _Context.SaveChanges();
            return Ok("you can reset your password");
        }

        [HttpPost("Reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPass request)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(u => u.Passwordresettoken == request.Token);
            //if (user == null || user.expiretoken < DateTime.Now)
            //{
            //    return BadRequest("invalid token ");
            //}
            CreatePasswordHash(request.Pass, out byte[] passwordHash, out byte[] passwordSalt);
            if (user is not null)
            {
                user.PassHash = passwordHash;
                user.PassSalt = passwordSalt;
                user.Passwordresettoken = null;
            }
            //user.expiretoken = null;
            await _Context.SaveChangesAsync();
            return Ok("password successfully changed");
        }



        private async Task<string> Createtoken(User request)
        {
            var comparison2 = await _Context.Users.FirstOrDefaultAsync(req => req.Storename == request.Storename);
            if (comparison2 is not null)
            {
                List<Claim> claims = new()
            {
                new Claim (ClaimTypes.Name, comparison2.Storename),
                new Claim (ClaimTypes.Role, "admin"),
            };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hello hayat shargh"));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }else { return ""; }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

    }
}
