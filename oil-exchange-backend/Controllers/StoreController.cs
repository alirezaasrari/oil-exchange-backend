using Microsoft.AspNetCore.Mvc;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models.ViewModels;
using oil_exchange_backend.Models;

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
        public async Task<ActionResult<UserVM>> AddToStore(StoreManagementVM request)
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
           
            
           
            
            await _Context.Store.AddAsync(_storemanagement);
            _Context.SaveChanges();
            return Ok(_storemanagement);
        }
    }
}
