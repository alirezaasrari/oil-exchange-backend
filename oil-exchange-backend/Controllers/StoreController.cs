﻿using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : Controller
    {
        private readonly DataContext _Context;
        public StoreController(DataContext Context)
        {
            _Context = Context;
        }
        [HttpPost("addtostore")]
        public async Task<ActionResult<StoreManagement>> AddToStore(StoreManagementVM request)
        {
            try
            {
                StoreManagement _storemanagement = new()
                {
                    Userid = request.Userid,
                    Registereddate = request.Registereddate,

                    Oilfilterselled = request.Oilfilterselled,
                    Oilfilterbuyed = request.Oilfilterbuyed,

                    Petrolfilterselled = request.Petrolfilterselled,
                    Petrolfilterbuyed = request.Petrolfilterbuyed,

                    Airfilterselled = request.Airfilterselled,
                    Airfilterbuyed = request.Airfilterbuyed,

                    Cabinfilterselled = request.Cabinfilterselled,
                    Cabinfilterbuyed = request.Cabinfilterbuyed,

                    Breakeoilselled = request.Breakeoilselled,
                    Breakeoilbuyed = request.Breakeoilbuyed,

                    Engineoilselled = request.Engineoilselled,
                    Engineoilbuyed = request.Engineoilbuyed,

                    Untifreezselled = request.Untifreezselled,
                    Untifreezbuyed = request.Untifreezbuyed,

                    Hydraulicoilbuyed = request.Hydraulicoilbuyed,
                    Hydraulicoilselled = request.Hydraulicoilselled,

                    Gearboxoilselled = request.Gearboxoilselled,
                    Gearboxoilbuyed = request.Gearboxoilbuyed
                };
                _Context.Store.Add(_storemanagement);
                await _Context.SaveChangesAsync();
                return Ok(_storemanagement);
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
                };
            }
            
        }
        [HttpGet("getstore")]
        public async Task<ActionResult <List<StoreManagement>>> Getstore(int request)
        {
            try
            {
                var store = await _Context.Store.ToListAsync();
                var filterdlist = Search(store, request);
                return Ok(filterdlist);
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
                };
            }
            
        }

        private static List<StoreManagement> Search(List<StoreManagement> list, int num)
        {
            try
            {
                var newlist = new List<StoreManagement>();
                foreach (StoreManagement p in list)
                {
                    if (p.Userid == num)
                    {
                        newlist.Add(p);
                    };
                }
                return newlist;
            }
            catch (Exception ex)
            {
                var ineerexception = ex.InnerException;
                if (ineerexception != null)
                {
                     Console.WriteLine(ineerexception.Message);
                    return new List<StoreManagement>();
                }
                else
                {
                     Console.WriteLine("bad request");
                    return new List<StoreManagement>();
                };

            }
            
        }
        [HttpGet("getstorename")]
        public async Task<ActionResult<string>> GetStoreName(string token)
        {
            var tokencheck = await _Context.Users.FirstOrDefaultAsync(a => a.Token == token);
            if (tokencheck == null)
            {
                return NotFound("user doesnt exist");
            }
            var storename = tokencheck.Storename;
            return Ok(storename);
        }
    }
}
