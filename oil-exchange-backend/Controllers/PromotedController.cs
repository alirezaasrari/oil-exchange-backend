using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotedController : ControllerBase
    {
        private readonly DataContext _context;

        public PromotedController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("promote"), Authorize]
        public async Task<IActionResult> Promote (PromotedDto request)
        {
            Promoted promoted = new() 
            {
                Userid = request.Userid,
                Promoteddate = DateTime.Now,
            };

             _context.Promotedusers.Add(promoted);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("get-promoted"), Authorize]
        public async Task<ActionResult<string>> DatePromoted(int request)
        {
            var user = await _context.Promotedusers.FirstOrDefaultAsync(e => e.Userid == request);
            if (user is null)
            {
                return BadRequest();
            }
            var date = user.Promoteddate;
            return Ok(date.ToString());

        }
    }
}
