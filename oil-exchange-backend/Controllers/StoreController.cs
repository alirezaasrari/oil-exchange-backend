using Microsoft.AspNetCore.Mvc;
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
        private DataContext _Context;
        public StoreController(DataContext Context)
        {
            _Context = Context;
        }
        [HttpPost("addtostore")]
        public async Task<ActionResult<StoreManagement>> AddToStore(StoreManagementVM request)
        {
            StoreManagement _storemanagement = new StoreManagement();
            _storemanagement.userid = request.userid;
            _storemanagement.registereddate = request.registereddate;

            _storemanagement.oilfilterselled = request.oilfilterselled;
            _storemanagement.oilfilterbuyed = request.oilfilterbuyed;

            _storemanagement.petrolfilterselled = request.petrolfilterselled;
            _storemanagement.petrolfilterbuyed = request.petrolfilterbuyed;

            _storemanagement.airfilterselled = request.airfilterselled; 
            _storemanagement.airfilterbuyed = request.airfilterbuyed;

            _storemanagement.cabinfilterselled = request.cabinfilterselled;
            _storemanagement.cabinfilterbuyed = request.cabinfilterbuyed;

            _storemanagement.breakeoilselled = request.breakeoilselled;
            _storemanagement.breakeoilbuyed = request.breakeoilbuyed;

            _storemanagement.engineoilselled = request.engineoilselled;
            _storemanagement.engineoilbuyed = request.engineoilbuyed;

            _storemanagement.untifreezselled = request.untifreezselled;
            _storemanagement.untifreezbuyed = request.untifreezbuyed;

            _storemanagement.hydraulicoilbuyed = request.hydraulicoilbuyed;
            _storemanagement.hydraulicoilselled = request.hydraulicoilselled;

            _storemanagement.gearboxoilselled = request.gearboxoilselled;
            _storemanagement.gearboxoilbuyed = request.gearboxoilbuyed;
           
            
           
            
            _Context.Store.Add(_storemanagement);
            await _Context.SaveChangesAsync();
            return Ok(_storemanagement);
        }
        [HttpGet("getstore")]
        public async Task<ActionResult <List<StoreManagement>>> getstore(int request)
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
    }
}
