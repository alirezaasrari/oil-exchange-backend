using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryCheckController : Controller
    {
        private DataContext _Context;
        public HistoryCheckController(DataContext Context)
        {
            _Context = Context;
        }
        [HttpGet("historycheck")]
        public async Task<ActionResult<List<CustomerManagement>>> HistoryCheck(string plaquenumber)
        {
            var history = await _Context.customermanagement.ToListAsync();
            var newlist = Search(history, plaquenumber);
            return Ok(newlist);
        }

        private List<CustomerManagement> Search(List<CustomerManagement> list, string num)
        {
            var newlist = new List<CustomerManagement>();
            foreach (CustomerManagement p in list) {
                if(p.plaque == num)
                {
                    newlist.Add(p);
                };
            } 
            return newlist;
        }
    }
}
