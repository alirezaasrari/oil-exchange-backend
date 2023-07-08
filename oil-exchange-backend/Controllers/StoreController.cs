﻿using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;

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
            StoreManagement _storemanagement = new()
            {
                userid = request.userid,
                registereddate = request.registereddate,

                oilfilterselled = request.oilfilterselled,
                oilfilterbuyed = request.oilfilterbuyed,

                petrolfilterselled = request.petrolfilterselled,
                petrolfilterbuyed = request.petrolfilterbuyed,

                airfilterselled = request.airfilterselled,
                airfilterbuyed = request.airfilterbuyed,

                cabinfilterselled = request.cabinfilterselled,
                cabinfilterbuyed = request.cabinfilterbuyed,

                breakeoilselled = request.breakeoilselled,
                breakeoilbuyed = request.breakeoilbuyed,

                engineoilselled = request.engineoilselled,
                engineoilbuyed = request.engineoilbuyed,

                untifreezselled = request.untifreezselled,
                untifreezbuyed = request.untifreezbuyed,

                hydraulicoilbuyed = request.hydraulicoilbuyed,
                hydraulicoilselled = request.hydraulicoilselled,

                gearboxoilselled = request.gearboxoilselled,
                gearboxoilbuyed = request.gearboxoilbuyed
            };




            _Context.Store.Add(_storemanagement);
            await _Context.SaveChangesAsync();
            return Ok(_storemanagement);
        }
        [HttpGet("getstore")]
        public async Task<ActionResult <List<StoreManagement>>> Getstore(int request)
        {
            var store = await _Context.Store.ToListAsync();
            var filterdlist = Search(store,request);
            return Ok(filterdlist);
        }

        private static List<StoreManagement> Search(List<StoreManagement> list, int num)
        {
            var newlist = new List<StoreManagement>();
            foreach (StoreManagement p in list)
            {
                if (p.userid == num)
                {
                    newlist.Add(p);
                };
            }
            return newlist;
        }
        [HttpGet("getstorename")]
        public async Task<ActionResult<string>> GetStoreName(string token)
        {
            var tokencheck = await _Context.users.FirstOrDefaultAsync(a => a.Token == token);
            if (tokencheck == null)
            {
                return NotFound("user doesnt exist");
            }
            var storename = tokencheck.Storename;
            return Ok(storename);
        }
    }
}